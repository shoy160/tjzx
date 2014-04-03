using System;

namespace Tjzx.Official.Controllers.ViewModels
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FileNameAttribute : Attribute
    {
        public string Name { get; set; }

        public FileNameAttribute(string name)
        {
            Name = name;
        }
    }
}
