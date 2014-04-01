using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Abstract
{
    public interface IRepository<T>
        where T : EntityBase
    {
        IEnumerable<T> Values { get; }
    }
}
