using System.Web.Mvc;
using Tjzx.Official.Models.Concrete;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Controllers
{
    public class MedicalPackageController : Controller
    {
        [HttpGet]
        public JsonResult Insert()
        {
            using (var db = new EFDbContext())
            {
                var item = db.MedicalPackages.Add(new MedicalPackage
                    {
                        Name = "常规体检(女)",
                        CategoryId = 1,
                        MarketPrice = 2800,
                        Price = 2000,
                        Feature = "实用性",
                        ForTheCrowd = "屌丝们",
                        Recommends = "体重，身高",
                        Details = "具体的描述"
                    });
                db.SaveChanges();
                return new JsonResult {Data = new {id = item.Id}, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }
        }
    }
}
