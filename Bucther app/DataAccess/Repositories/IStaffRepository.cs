using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public interface IStaffRepository : IRepository<Staff, Guid>
    {
        Task<Staff> AuthenticateAsync(string pinCode);
        Task<Staff> GetByPinCodeAsync(string pinCode);
    }
}
