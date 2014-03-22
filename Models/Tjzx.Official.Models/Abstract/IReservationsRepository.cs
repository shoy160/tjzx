using System.Collections.Generic;
using Tjzx.Official.Models.Entities;

namespace Tjzx.Official.Models.Abstract
{
    public interface IReservationsRepository
    {
        IEnumerable<Reservation> Reservations { get; } 
    }
}
