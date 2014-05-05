﻿using System.Web.Mvc;
using Tjzx.Official.BLL.Attributes;
using Tjzx.Official.BLL.Dict;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.Manager
{
    public class DiseasesController:BaseController
    {
        [Auth(Role = ManagerRole.Diseases)]
        public ActionResult Index()
        {
            return View("/Views/Manager/DiseasesList.cshtml");
        }
    }
}
