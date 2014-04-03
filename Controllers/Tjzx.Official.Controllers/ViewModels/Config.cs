using System;
using System.Linq;
using Tjzx.Web;
using System.Xml.Serialization;

namespace Tjzx.Official.Controllers.ViewModels
{
    [Serializable]
    public class Config<T>
        where T:class
    {
        private string _fileName;

        public static Config<T> Instance()
        {
            return new Config<T>();
        }

        [XmlIgnore]
        public string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(_fileName))
                {
                    var attrs = typeof (T).GetCustomAttributes(typeof (FileNameAttribute), true);
                    if (attrs.Any())
                    {
                        var attr = attrs.FirstOrDefault() as FileNameAttribute;
                        if (attr != null) _fileName = attr.Name;
                    }
                }
                return _fileName;
            }
        }

        public T Get(string fileName = "")
        {
            if (string.IsNullOrEmpty(fileName)) fileName = FileName;
            return ConfigManager.GetConfig<T>(fileName);
        }

        public void Set(T config, string fileName = "")
        {
            if (string.IsNullOrEmpty(fileName)) fileName = FileName;
            ConfigManager.SetConfig(fileName, config);
        }
    }
}
