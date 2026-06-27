using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public interface IClientRepository : IRepository<Client, Guid>
    {
        Task<Client> GetByPhoneAsync(string phoneNumber);
        Task<Client> CreateClientIfNotExists(string phoneNumber, string firstName, string lastName);
    }
}
