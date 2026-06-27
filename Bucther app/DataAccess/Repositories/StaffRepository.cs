using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public class StaffRepository : RepositoryBase<Staff, Guid>, IStaffRepository
    {
        public StaffRepository(DatabaseContext context) : base(context) { }

        protected override string GetByIdQuery => "sp_GetStaffById";
        protected override string GetAllQuery => "sp_GetAllStaff";
        protected override string InsertQuery => "sp_InsertStaff";
        protected override string UpdateQuery => "sp_UpdateStaff";
        protected override string DeleteQuery => "sp_DeleteStaff";

        public async Task<Staff> AuthenticateAsync(string pinCode)
        {
            var parameters = new { PinCode = pinCode };
            return await _context.QueryFirstOrDefaultAsync<Staff>("sp_AuthenticateStaff", parameters);
        }

        public async Task<Staff> GetByPinCodeAsync(string pinCode)
        {
            var parameters = new { PinCode = pinCode };
            return await _context.QueryFirstOrDefaultAsync<Staff>("sp_GetStaffByPin", parameters);
        }
    }
}
