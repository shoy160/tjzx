using System.Collections.Generic;
using System.ComponentModel;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class TestReservationsRepository : IRepository<Reservation>
    {
        public IEnumerable<Reservation> Values
        {
            get { return new BindingList<Reservation>(); }
        }
    }
}
