using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFReservationsRepository : EFRepositoryBase<Reservation>
    {
        public override IEnumerable<Reservation> GetValues()
        {
            return Context.Reservations;
        }
    }
}
