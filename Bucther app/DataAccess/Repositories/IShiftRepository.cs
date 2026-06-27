using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public interface IShiftRepository : IRepository<WorkShift, Guid>
    {
        Task<WorkShift> OpenShiftAsync(Guid staffId, string zoneName);
        Task<bool> CloseShiftAsync(Guid shiftId);
        Task<bool> AssignTablesToShiftAsync(Guid shiftId, IEnumerable<Guid> tableIds);
        Task<IEnumerable<WorkShift>> GetShiftsByStaffAsync(Guid staffId);
        Task<WorkShift> GetCurrentShiftForStaffAsync(Guid staffId);
    }
}
