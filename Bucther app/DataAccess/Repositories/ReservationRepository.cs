using Bucther_app.DataAccess.Helpers;
using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public class ReservationRepository : RepositoryBase<Reservation, Guid>, IReservationRepository
    {
        public ReservationRepository(DatabaseContext context) : base(context) { }

        protected override string GetByIdQuery => "sp_GetReservationById";
        protected override string GetAllQuery => "sp_GetAllReservations";
        protected override string InsertQuery => "sp_InsertReservation";
        protected override string UpdateQuery => "sp_UpdateReservation";
        protected override string DeleteQuery => "sp_DeleteReservation";

        public async Task<Reservation> CreateReservationAsync(Guid clientId, Guid tableId, DateTime resTime, int guestsCount, string comment = null)
        {
            var parameters = new { ClientId = clientId, TableId = tableId, ResTime = resTime, GuestsCount = guestsCount, Comment = comment };
            return await SqlExceptionHelper.ExecuteWithErrorHandling(async () =>
            {
                return await _context.QueryFirstOrDefaultAsync<Reservation>("sp_CreateReservation", parameters);
            });
        }

        public async Task<bool> CancelReservationAsync(Guid reservationId)
        {
            var parameters = new { ReservationId = reservationId };
            var result = await _context.ExecuteAsync("sp_CancelReservation", parameters);
            return result > 0;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByClientAsync(Guid clientId)
        {
            var parameters = new { ClientId = clientId };
            return await _context.QueryAsync<Reservation>("sp_GetReservationsByClient", parameters);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByTableAsync(Guid tableId)
        {
            var parameters = new { TableId = tableId };
            return await _context.QueryAsync<Reservation>("sp_GetReservationsByTable", parameters);
        }

        public async Task<bool> IsTableReservedAtTime(Guid tableId, DateTime time)
        {
            var parameters = new { TableId = tableId, TargetTime = time };
            var result = await _context.QueryFirstOrDefaultAsync<int?>("sp_IsTableReservedAtTime", parameters);
            return result.HasValue && result.Value > 0;
        }
    }
}
