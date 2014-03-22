using System.Collections.Generic;
using Tjzx.Official.Models.Abstract;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Concrete
{
    public class EFReservationRepository:IReservationsRepository
    {
        private readonly EFDbContext _context = new EFDbContext();
        public IEnumerable<Reservation> Reservations
        {
            get { return _context.Reservations; }
        }
    }
}
