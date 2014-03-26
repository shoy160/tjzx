using System.Web.Mvc;
using Ninject;
using Tjzx.Official.Models.Abstract;

namespace Tjzx.Official.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {}

        [Inject]
        public IRepository Repository { get; set; }
    }
}
