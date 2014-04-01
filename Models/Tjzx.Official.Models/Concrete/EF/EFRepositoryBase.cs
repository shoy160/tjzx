using System.Collections.Generic;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public abstract class EFRepositoryBase<T> : IRepository<T>
        where T : EntityBase
    {
        internal EFDbContext Context = new EFDbContext();

        public abstract IEnumerable<T> GetValues();

        public IEnumerable<T> Values
        {
            get { return GetValues(); }
        }
    }
}
