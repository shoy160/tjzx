using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;
using System;

namespace Tjzx.Official.Models.Test
{
    [TestClass]
    public class MedicalPackageTest
    {
        [TestMethod]
        public void Insert_Test()
        {
            using (var db = new EFDbContext())
            {
                //if (!db.MedicalPackages.Any())
                {
                    db.MedicalPackages.Add(new MedicalPackage
                        {
                            Name = "常规体检(女)",
                            CategoryId = 1,
                            Type = 0,
                            MarketPrice = 2600,
                            Price = 2200,
                            Feature = "实用性",
                            ForTheCrowd = "屌丝们",
                            Recommends = "体重，身高",
                            Details = "具体的描述",
                            CreateOn = DateTime.Now,
                            CreatorId = 0,
                            Creator = "system",
                            Popularity = 0,
                            Sort = 0,
                            State = 1,
                            Sex = 2
                        });
                    db.SaveChanges();
                }
                Assert.AreEqual(2, db.MedicalPackages.Count());
            }
        }

        [TestMethod]
        public void QueryTest()
        {
            using (var db = new EFDbContext())
            {
                var item = db.MedicalPackages.FirstOrDefault();
                Assert.AreNotEqual(null, item);
                Assert.AreEqual("常规体检", item.Category.Name);
            }
        }
    }
}
