using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bucther_app.Models;

namespace Bucther_app.DataAccess.Repositories
{
    public interface ITableRepository : IRepository<Table, Guid>
    {
        // Получение свободных столов на конкретное время через функцию fn_GetFreeTables
        Task<IEnumerable<Table>> GetFreeTablesAsync(DateTime targetTime);
        // Получение столов по зоне
        Task<IEnumerable<Table>> GetTablesByZoneAsync(Guid zoneId);
        // Получение столов, закреплённых за сменой
        Task<IEnumerable<Table>> GetTablesByShiftAsync(Guid shiftId);
    }
}
