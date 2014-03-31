using System.Web.Mvc;
using Tjzx.Official.Models.Abstract;

namespace Tjzx.Web
{
    public class BaseController : Controller
    {
        public IMedicalPackageRepository Repository;

        public BaseController(){}

        public BaseController(IMedicalPackageRepository repository)
        {
            Repository = repository;
        }
    }
}
