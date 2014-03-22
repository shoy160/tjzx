using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;
using System.Collections.Generic;
using Tjzx.Official.Models.Concrete;

namespace Tjzx.Infrastructure.Factory
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext
                                                                 requestContext, Type controllerType)
        {

            return controllerType == null ? null : (IController) ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            //var mock = new Mock<IMedicalPackagesRepository>();
            //mock.Setup(m => m.MedicalPackages).Returns(new List<MedicalPackage>
            //    {
            //        new MedicalPackage
            //            {
            //                Id = 1001,
            //                Name = "常规套餐(男)",
            //                MarketPrice = 2500,
            //                Price = 1800,
            //                Type = 0,
            //                Details = "详情",
            //                Feature = "套餐特点",
            //                ForTheCrowd = "适用人群",
            //                Recommends = "推荐项目"
            //            }
            //    }.AsQueryable());
            //ninjectKernel.Bind<IMedicalPackagesRepository>().ToConstant(mock.Object);
            ninjectKernel.Bind<IMedicalPackagesRepository>().To<EFMedicalPackageRepository>();
        }
    }
}
