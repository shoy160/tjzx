using System;
using System.Xml.Serialization;
using Tjzx.BLL.Config;

namespace Tjzx.Official.BLL.Config
{
    [Serializable]
    [XmlRoot("root")]
    [FileName("tjzx.config")]
    public class TjzxConfig : ConfigBase
    {
        [XmlElement("uploader")]
        public UploaderConfig Uploader { get; set; }

        [XmlElement("email")]
        public EmailConfig Email { get; set; }
    }

    [Serializable]
    public class UploaderConfig
    {
        /// <summary>
        /// 上传文件根目录
        /// </summary>
        [XmlAttribute("base")]
        public string BasePath { get; set; }

        [XmlArray("dir")]
        [XmlArrayItem("item")]
        public string[] Directories { get; set; }

        /// <summary>
        /// 允许的图片类型
        /// </summary>
        [XmlElement("imageExts")]
        public string ImageExts { get; set; }

        /// <summary>
        /// 图片大小限制(单位:k)
        /// </summary>
        [XmlElement("imageLimit")]
        public int ImageSizeLimit { get; set; }

        /// <summary>
        /// 允许的附件类型
        /// </summary>
        [XmlElement("attachExts")]
        public string AttachExts { get; set; }

        /// <summary>
        /// 附件大小限制(单位:k)
        /// </summary>
        [XmlElement("attachLimit")]
        public int AttachSizeLimit { get; set; }
    }

    /// <summary>
    /// 邮件配置
    /// </summary>
    [Serializable]
    public class EmailConfig
    {
        /// <summary>
        /// 发送邮箱
        /// </summary>
        [XmlAttribute("senderEmail")]
        public string SenderEmail { get; set; }

        /// <summary>
        /// 发件箱密码
        /// </summary>
        [XmlAttribute("senderPwd")]
        public string SenderPwd { get; set; }

        /// <summary>
        /// 发件者
        /// </summary>
        [XmlAttribute("senderName")]
        public string SenderName { get; set; }

        /// <summary>
        /// smtp 站点
        /// </summary>
        [XmlAttribute("smtpHost")]
        public string SmtpHost { get; set; }

        /// <summary>
        /// smtp 端口号
        /// </summary>
        [XmlAttribute("smtpPort")]
        public int SmtpPort { get; set; }

        /// <summary>
        /// 是否启用https
        /// </summary>
        [XmlAttribute("useSsl")]
        public bool UseSsl { get; set; }
    }
}
