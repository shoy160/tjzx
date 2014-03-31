using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Concrete;

namespace Tjzx.Web.Resolver
{
    /// <summary>
    /// Ninject 依赖项注入
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<IMedicalPackageRepository>().To<EFMedicalPackagesRepository>();
            _kernel.Bind<IPackageCategoryRepository>().To<EFPackageCategoriesRepository>();
            _kernel.Bind<IReservationRepository>().To<EFReservationsRepository>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}
