using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFNewsesRepository:EFRepositoryBase<News>
    {
        public override IEnumerable<News> GetValues()
        {
            return Context.Newses;
        }
    }
}
