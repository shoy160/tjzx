using System;

namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 体检套餐业务类
    /// </summary>
    public class PackageInfo:InfoBase
    {
        public int PackageId { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string Picture { get; set; }

        public byte Sex { get; set; }

        public byte Type { get; set; }

        public string ForTheCrowd { get; set; }

        public string Feature { get; set; }

        public string Recommends { get; set; }

        public string Details { get; set; }

        public DateTime CreateOn { get; set; }

        public byte State { get; set; }

        public int Sort { get; set; }
    }
}
