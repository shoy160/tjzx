using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Concrete;

namespace Tjzx.Infrastructure.Factory
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IRepository>().To<EFRepository>();
        }
    }
}
