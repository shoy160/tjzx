using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shoy.Utility.Extend;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;
namespace Tjzx.Official.Models.Test
{
    [TestClass]
    public class SpiderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var db = new EFDbContext())
            {
                int count;
                var list = db.Paging<Diseases>(new DataPage
                    {
                        Table = "Diseases",
                        PrimaryKey = "DiseasesId",
                        Sort = "DiseasesId desc",
                        Fields = "*",
                        PageIndex = 5,
                        PageSize = 5,
                        Filter = "DiseasesDepartmentId=1012",
                        Group = ""
                    }, out count).ToList();
                Console.WriteLine(list.Select(t => new
                    {
                        t.DiseasesId,
                        t.DiseasesName,
                        t.DiseasesDepartmentId
                    }).ToJson());

                Console.WriteLine(count);
            }
        }
    }
}
