using System;

namespace Tjzx.Official.BLL.ViewModels
{
    public class DiseasesInfo : InfoBase
    {
        public int DiseasesId { get; set; }
        public string DiseasesName { get; set; }
        public int DiseasesDepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DiseasesDescription { get; set; }
        public int? Sort { get; set; }
        public byte State { get; set; }
        public DateTime CreateOn { get; set; }
        public int CreatorId { get; set; }
        public string Creator { get; set; }
    }
}
