using System;
using System.Linq;
namespace Tjzx.Official.BLL.ViewModels
{
    /// <summary>
    /// 管理员业务类
    /// </summary>
    public class ManagerInfo : InfoBase
    {
        public int UserId { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int[] Roles { get; set; }

        public int Role
        {
            get { return (Roles != null && Roles.Length > 0) ? Roles.Aggregate(0, (current, role) => current | role) : 0; }
        }

        public string Ticket { get; set; }

        public byte State { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
