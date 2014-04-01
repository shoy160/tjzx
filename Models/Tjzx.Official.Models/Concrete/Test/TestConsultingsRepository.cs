using System.Collections.Generic;
using System.ComponentModel;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class TestConsultingsRepository : IRepository<Consulting>
    {
        public IEnumerable<Consulting> Values
        {
            get { return new BindingList<Consulting>(); }
        }
    }
}
