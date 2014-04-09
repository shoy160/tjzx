using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Ninject;

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
            //AddBindings();
        }

        //private void AddBindings()
        //{
        //    var dbMode = ConfigurationManager.AppSettings.Get("dbMode");
        //    switch (dbMode)
        //    {
        //        case "EF":
        //            BindingsEf();
        //            break;
        //        default:
        //            BindingsTest();
        //            break;
        //    }
        //}

        //private void BindingsTest()
        //{
        //    _kernel.Bind<IRepository<MedicalPackage>>().To<TestMedicalPackagesRepository>();
        //    _kernel.Bind<IRepository<PackageCategory>>().To<TestPackageCategoriesRepository>();
        //    _kernel.Bind<IRepository<Reservation>>().To<TestReservationsRepository>();
        //    _kernel.Bind<IRepository<News>>().To<TestNewsesRepository>();
        //    _kernel.Bind<IRepository<Member>>().To<TestMembersRepository>();
        //    _kernel.Bind<IRepository<Consulting>>().To<TestConsultingsRepository>();
        //}

        //private void BindingsEf()
        //{
        //    _kernel.Bind<IRepository<MedicalPackage>>().To<EFMedicalPackagesRepository>();
        //    _kernel.Bind<IRepository<PackageCategory>>().To<EFPackageCategoriesRepository>();
        //    _kernel.Bind<IRepository<Reservation>>().To<EFReservationsRepository>();
        //    _kernel.Bind<IRepository<News>>().To<EFNewsesRepository>();
        //    _kernel.Bind<IRepository<Member>>().To<EFMembersRepository>();
        //    _kernel.Bind<IRepository<Consulting>>().To<EFConsultingsRepository>();
        //}

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
