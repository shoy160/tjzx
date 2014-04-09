using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class ReservationController:BaseController
    {
        [Auth(Role = ManagerRole.Reservation)]
        public ActionResult Index()
        {
            return View("/Views/Manager/Reservations.cshtml");
        }
    }
}
