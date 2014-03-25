﻿using System.Linq;
using System.Web.Mvc;
using Tjzx.Official.Models.Abstract;
using Tjzx.Web;

namespace Tjzx.Official.Controllers
{
    public class HomeController:Controller
    {
        private readonly IMedicalPackagesRepository _repository;

        public HomeController(IMedicalPackagesRepository productRepository)
        {
            _repository = productRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "首页";
            Logger.Debug("dddddd");
            return View(_repository.MedicalPackages.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Title = "关于我们";
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Package()
        {
            return View();
        }

        public ActionResult Reservation()
        {
            return View();
        }
    }
}
