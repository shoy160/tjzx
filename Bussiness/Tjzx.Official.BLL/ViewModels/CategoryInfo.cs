using System;
namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 套餐分类业务类
    /// </summary>
    public class CategoryInfo : InfoBase
    {
        public int CateId { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public byte State { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
