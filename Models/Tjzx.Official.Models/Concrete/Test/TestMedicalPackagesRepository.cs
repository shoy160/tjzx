using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class TestMedicalPackagesRepository : IRepository<MedicalPackage>
    {
        public IEnumerable<MedicalPackage> Values
        {
            get
            {
                return new BindingList<MedicalPackage>
                    {
                        new MedicalPackage
                            {
                                PackageId = 1,
                                CategoryId = 1,
                                Category = new PackageCategory {CategoryId = 1, Name = "常规套餐", Sort = 0, State = 1},
                                Name = "常规体检套餐(男)",
                                CreateOn = DateTime.Now,
                                CreatorId = 0,
                                Creator = "test",
                                Details = "描述",
                                Feature = "",
                                ForTheCrowd = "适用人群",
                                Popularity = 0,
                                Price = 1200,
                                MarketPrice = 1500
                            }
                    };
            }
        }
    }
}
