namespace Tjzx.Official.BLL.ViewModels
{
    public class DiseasesDepartmentInfo:InfoBase
    {
        public int DiseasesDepartmentId { get; set; }
        public string DiseasesDepartmentName { get; set; }
        public int? Sort { get; set; }
        public byte State { get; set; }
    }
}
