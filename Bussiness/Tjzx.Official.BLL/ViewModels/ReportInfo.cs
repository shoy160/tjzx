namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 体检报告业务类
    /// </summary>
    public class ReportInfo:InfoBase
    {
        public int ReportId { get; set; }

        /// <summary>
        /// 体检号
        /// </summary>
        public string MedicalNum { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// 报告内容
        /// </summary>
        public string ReportContent { get; set; }
    }
}
