using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bucther_app.Models;

namespace Bucther_app.DataAccess.Repositories
{
    public class TableRepository : RepositoryBase<Table, Guid>, ITableRepository
    {
        public TableRepository(DatabaseContext context) : base(context) { }

        protected override string GetByIdQuery => "sp_GetTableById";
        protected override string GetAllQuery => "sp_GetAllTables";
        protected override string InsertQuery => "sp_InsertTable";
        protected override string UpdateQuery => "sp_UpdateTable";
        protected override string DeleteQuery => "sp_DeleteTable";

        // Вызов функции fn_GetFreeTables
        public async Task<IEnumerable<Table>> GetFreeTablesAsync(DateTime targetTime)
        {
            // Функция возвращает таблицу, используем SELECT * FROM fn_GetFreeTables(@target_time)
            var sql = "SELECT * FROM fn_GetFreeTables(@targetTime)";
            var parameters = new { targetTime };
            return await _context.QueryAsync<Table>(sql, parameters, CommandType.Text);
        }

        public async Task<IEnumerable<Table>> GetTablesByZoneAsync(Guid zoneId)
        {
            var parameters = new { ZoneId = zoneId };
            return await _context.QueryAsync<Table>("sp_GetTablesByZone", parameters);
        }

        public async Task<IEnumerable<Table>> GetTablesByShiftAsync(Guid shiftId)
        {
            var parameters = new { ShiftId = shiftId };
            return await _context.QueryAsync<Table>("sp_GetTablesByShift", parameters);
        }
    }
}
