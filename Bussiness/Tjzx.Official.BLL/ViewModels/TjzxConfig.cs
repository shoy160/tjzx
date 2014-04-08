using System.Xml.Serialization;
using Tjzx.Official.BLL.Attributes;
using System;

namespace Tjzx.Official.BLL.ViewModels
{
    [Serializable]
    [XmlRoot("root")]
    [FileName("tjzx.config")]
    public class TjzxConfig
    {
        [XmlElement("uploader")]
        public UploaderConfig Uploader { get; set; }
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
}
