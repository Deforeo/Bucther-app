using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public interface IReservationRepository : IRepository<Reservation, Guid>
    {
        Task<Reservation> CreateReservationAsync(Guid clientId, Guid tableId, DateTime resTime, int guestsCount, string comment = null);
        Task<bool> CancelReservationAsync(Guid reservationId);
        Task<IEnumerable<Reservation>> GetReservationsByClientAsync(Guid clientId);
        Task<IEnumerable<Reservation>> GetReservationsByTableAsync(Guid tableId);
        Task<bool> IsTableReservedAtTime(Guid tableId, DateTime time);
    }
}
