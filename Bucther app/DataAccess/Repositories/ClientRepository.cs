using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public class ClientRepository : RepositoryBase<Client, Guid>, IClientRepository
    {
        public ClientRepository(DatabaseContext context) : base(context) { }

        protected override string GetByIdQuery => "sp_GetClientById";
        protected override string GetAllQuery => "sp_GetAllClients";
        protected override string InsertQuery => "sp_InsertClient";
        protected override string UpdateQuery => "sp_UpdateClient";
        protected override string DeleteQuery => "sp_DeleteClient";

        public async Task<Client> GetByPhoneAsync(string phoneNumber)
        {
            var parameters = new { PhoneNumber = phoneNumber };
            return await _context.QueryFirstOrDefaultAsync<Client>("sp_GetClientByPhone", parameters);
        }

        public async Task<Client> CreateClientIfNotExists(string phoneNumber, string firstName, string lastName)
        {
            var parameters = new { PhoneNumber = phoneNumber, FirstName = firstName, LastName = lastName };
            return await _context.QueryFirstOrDefaultAsync<Client>("sp_CreateClientIfNotExists", parameters);
        }
    }
}
