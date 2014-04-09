using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Shoy.Utility;
using Shoy.Utility.Extend;
using Tjzx.BLL;
using Tjzx.BLL.Config;
using Tjzx.Official.BLL.Config;

namespace Tjzx.Official.BLL
{
    /// <summary>
    /// 文件上传辅助
    /// </summary>
    public class Uploader
    {
        private readonly UploaderConfig _config;
        private string _basePath;
        private string _urlPath;
        private readonly HttpContext _context;
        private readonly Logger _logger = Logger.L<Uploader>();

        public static string[] GetDirectories()
        {
            var config = ConfigUtils<TjzxConfig>.Instance().Get();
            return config.Uploader.Directories;
        }

        public IEnumerable<string> GetFiles(UploadType type = UploadType.Image)
        {
            var list = new List<string>();
            var exts = (type == UploadType.Image ? _config.ImageExts : _config.AttachExts).Split(',');
            foreach (var dir in GetDirectories())
            {
                var path = Path.Combine(_urlPath, dir);
                var info = new DirectoryInfo(_context.Server.MapPath(path));
                if (info.Exists)
                {
                    list.AddRange(GetFiles(path, info, exts));
                }
            }
            return list;
        }

        private IEnumerable<string> GetFiles(string path, DirectoryInfo dir, IEnumerable<string> exts)
        {
            var pics = new List<string>();
            if (dir.Exists)
            {
                pics.AddRange(
                    dir.GetFiles()
                       .Where(t => exts.Contains(Path.GetExtension(t.Name)))
                       .Select(file => Path.Combine(path, file.Name).Replace("\\", "/")));
                foreach (var directory in dir.GetDirectories())
                {
                    pics.AddRange(GetFiles(Path.Combine(path, directory.Name), directory, exts ?? new string[] {}));
                }
            }
            return pics;
        }

        public Uploader(HttpContext context)
        {
            _context = context;
            var config = ConfigUtils<TjzxConfig>.Instance().Get();
            if (config != null)
            {
                _config = config.Uploader;
                _basePath = _context.Server.MapPath(_config.BasePath);
                _urlPath = _config.BasePath;
                if (!Directory.Exists(_basePath))
                {
                    Directory.CreateDirectory(_basePath);
                }
            }
        }

        public Hashtable SaveFile(string dir = "",UploadType type = UploadType.Image)
        {
            if (_context == null || _context.Request.Files.Count == 0)
            {
                return new Hashtable {{"state", "请选择要上传的文件！"}, {"url", ""}};
            }
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
            var file = _context.Request.Files[0];
            string fileName = file.FileName,
                   ext = Path.GetExtension(fileName);
            var exts = (type == UploadType.Image ? _config.ImageExts : _config.AttachExts);
            var limit = (type == UploadType.Image ? _config.ImageSizeLimit : _config.AttachSizeLimit);
            if (string.IsNullOrEmpty(ext) || !exts.Contains(ext))
            {
                return new Hashtable
                    {
                        {
                            "state",
                            string.Format("只能上传{0}格式的文件！", exts.Aggregate("", (c, t) => c + t + ",").TrimEnd(','))
                        },
                        {"url", ""}
                    };
            }
            if (file.ContentLength >= limit*1024)
            {
                return new Hashtable
                    {
                        {"state", string.Format("文件大小不能超过{0}k！", limit)},
                        {"url", ""}
                    };
            }
            string basePath = _basePath,
                   urlPath = _urlPath;
            if (!string.IsNullOrEmpty(dir))
            {
                basePath = Path.Combine(basePath, dir);
                if (!Directory.Exists(basePath))
                    Directory.CreateDirectory(basePath);
                urlPath = Path.Combine(urlPath, dir);
            }
            string name = Format("fileNameFormat".Query(""), fileName),
                   path = Path.Combine(basePath, name);
            var ai = 1;
            while (File.Exists(path))
            {
                path = Path.Combine(basePath, Path.GetFileNameWithoutExtension(name) + "_" + ai++ + ext);
            }
            _urlPath = Path.Combine(urlPath, Path.GetFileName(path) ?? "");
            if (type == UploadType.Image)
            {
                using (var img = new ImageCls(file.InputStream))
                {
                    if (!img.ResizeImg(path, 90))
                    {
                        return new Hashtable {{"state", "保存文件失败！"}, {"url", ""}};
                    }
                }
            }
            else
            {
                file.SaveAs(path);
            }
            return new Hashtable
                {
                    {"state", "SUCCESS"},
                    {"url", _urlPath},
                    {"currentType", ext},
                    {"originalName", fileName}
                };
        }

        /// <summary>
        /// 保存涂鸦
        /// </summary>
        /// <returns></returns>
        public Hashtable SaveScrawl(string base64Data, string tmpPath = "")
        {
            _urlPath = Path.Combine(_config.BasePath, DateTime.Now.ToString("yyyy-MM-dd") + "/");
            _basePath = _context.Server.MapPath(_urlPath); //获取文件上传路径
            FileStream fs = null;
            string state = "SUCCESS", url;
            try
            {
                if (!Directory.Exists(_basePath))
                {
                    Directory.CreateDirectory(_basePath);
                }
                //生成图片
                var fileName = Guid.NewGuid() + ".png";
                fs = File.Create(_basePath + fileName);
                byte[] bytes = Convert.FromBase64String(base64Data);
                fs.Write(bytes, 0, bytes.Length);
                url = _urlPath + fileName;
            }
            catch (Exception ex)
            {
                _logger.E("涂鸦文件上传出错", ex);
                state = "未知错误";
                url = "";
            }
            finally
            {
                if (fs != null)
                    fs.Close();
                if (!string.IsNullOrEmpty(tmpPath))
                {
                    tmpPath = _context.Server.MapPath(tmpPath);
                    if (Directory.Exists(tmpPath))
                    {
                        //Directory.Delete(tmpPath, true);
                    }
                }
            }
            return new Hashtable
                {
                    {"state", state},
                    {"url", url}
                };
        }

        private static string Format(string format, string filename)
        {
            if (String.IsNullOrWhiteSpace(format))
            {
                format = "{filename}{rand:6}";
            }
            string ext = Path.GetExtension(filename);
            filename = Path.GetFileNameWithoutExtension(filename);
            format = format.Replace("{filename}", filename);
            format = new Regex(@"\{rand(\:?)(\d+)\}", RegexOptions.Compiled).Replace(format, delegate(Match match)
            {
                var digit = 6;
                if (match.Groups.Count > 2)
                {
                    digit = Convert.ToInt32(match.Groups[2].Value);
                }
                var rand = new Random();
                return rand.Next((int)Math.Pow(10, digit), (int)Math.Pow(10, digit + 1)).ToString(CultureInfo.InvariantCulture);
            });
            format = format.Replace("{time}", DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture));
            format = format.Replace("{yyyy}", DateTime.Now.Year.ToString(CultureInfo.InvariantCulture));
            format = format.Replace("{yy}", (DateTime.Now.Year % 100).ToString("D2"));
            format = format.Replace("{mm}", DateTime.Now.Month.ToString("D2"));
            format = format.Replace("{dd}", DateTime.Now.Day.ToString("D2"));
            format = format.Replace("{hh}", DateTime.Now.Hour.ToString("D2"));
            format = format.Replace("{ii}", DateTime.Now.Minute.ToString("D2"));
            format = format.Replace("{ss}", DateTime.Now.Second.ToString("D2"));
            var invalidPattern = new Regex(@"[\\\/\:\*\?\042\<\>\|]");
            format = invalidPattern.Replace(format, "");
            return format + ext;
        }
    }

    public enum UploadType
    {
        Image = 0,
        Attach = 1
    }
}
