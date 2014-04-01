using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFConsultingsRepository : EFRepositoryBase<Consulting>
    {
        public override IEnumerable<Consulting> GetValues()
        {
            return Context.Consultings;
        }
    }
}
