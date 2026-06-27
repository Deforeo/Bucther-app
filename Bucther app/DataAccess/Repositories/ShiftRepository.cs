using Bucther_app.DataAccess.Helpers;
using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public class ShiftRepository : RepositoryBase<WorkShift, Guid>, IShiftRepository
    {
        public ShiftRepository(DatabaseContext context) : base(context) { }

        protected override string GetByIdQuery => "sp_GetShiftById";
        protected override string GetAllQuery => "sp_GetAllShifts";
        protected override string InsertQuery => "sp_InsertShift";
        protected override string UpdateQuery => "sp_UpdateShift";
        protected override string DeleteQuery => "sp_DeleteShift";

        public async Task<WorkShift> OpenShiftAsync(Guid staffId, string zoneName)
        {
            var parameters = new { StaffId = staffId, ZoneName = zoneName };
            return await SqlExceptionHelper.ExecuteWithErrorHandling(async () =>
            {
                return await _context.QueryFirstOrDefaultAsync<WorkShift>("sp_OpenShift", parameters);
            });
        }

        public async Task<bool> CloseShiftAsync(Guid shiftId)
        {
            var parameters = new { ShiftId = shiftId };
            var result = await _context.ExecuteAsync("sp_CloseShift", parameters);
            return result > 0;
        }

        public async Task<bool> AssignTablesToShiftAsync(Guid shiftId, IEnumerable<Guid> tableIds)
        {
            // Можно использовать табличный параметр или цикл.
            // Для простоты создадим хранимую процедуру, принимающую список ID столов.
            var tableIdsCsv = string.Join(",", tableIds);
            var parameters = new { ShiftId = shiftId, TableIds = tableIdsCsv };
            var result = await _context.ExecuteAsync("sp_AssignTablesToShift", parameters);
            return result > 0;
        }

        public async Task<IEnumerable<WorkShift>> GetShiftsByStaffAsync(Guid staffId)
        {
            var parameters = new { StaffId = staffId };
            return await _context.QueryAsync<WorkShift>("sp_GetShiftsByStaff", parameters);
        }

        public async Task<WorkShift> GetCurrentShiftForStaffAsync(Guid staffId)
        {
            var parameters = new { StaffId = staffId };
            return await _context.QueryFirstOrDefaultAsync<WorkShift>("sp_GetCurrentShiftForStaff", parameters);
        }
    }
}
