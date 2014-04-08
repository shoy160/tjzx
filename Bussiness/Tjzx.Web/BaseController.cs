using System.Web.Mvc;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Web
{
    public class BaseController:Controller
    {
        
    }

    public class BaseController<T> : Controller
        where T : EntityBase
    {
        public readonly IRepository<T> Repository;

        public BaseController() { }

        public BaseController(IRepository<T> repository)
        {
            Repository = repository;
        }
    }

    public class BaseController<T, TV> : Controller
        where T : EntityBase
        where TV : EntityBase
    {
        public readonly IRepository<T> RepositoryT;
        public readonly IRepository<TV> RepositoryTv;

        public BaseController(){}

        public BaseController(IRepository<T> repositoryT, IRepository<TV> repositoryTv)
        {
            RepositoryT = repositoryT;
            RepositoryTv = repositoryTv;
        }
    }
}
