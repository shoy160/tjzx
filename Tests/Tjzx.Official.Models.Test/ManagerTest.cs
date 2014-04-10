using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shoy.Utility.Extend;
using Tjzx.Official.BLL.Dict;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Test
{
    [TestClass]
    public class ManagerTest
    {
        [TestMethod]
        public void InitModel()
        {
            using (var db = new EFDbContext())
            {
                //var manager = new Manager
                //    {
                //        UserName = "shoy",
                //        PassWord = "a123456".Md5().ToLower(),
                //        RealName = "罗勇",
                //        State = (byte) StateType.Display,
                //        CreateOn = DateTime.Now,
                //        Mobile = "18782246531",
                //        Role =
                //            (ManagerRole.News | ManagerRole.Package | ManagerRole.Reservation | ManagerRole.Users |
                //             ManagerRole.Health)
                //                .GetValue()
                //    };
                //db.Managers.Add(manager);
                var item = db.Managers.FirstOrDefault();
                item.Role = ManagerRole.News.GetValue();
                db.SaveChanges();
                Assert.IsNotNull(db.Managers.FirstOrDefault());
            }
        }
    }
}
