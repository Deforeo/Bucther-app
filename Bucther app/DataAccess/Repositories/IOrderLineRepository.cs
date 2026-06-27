using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public interface IOrderLineRepository : IRepository<OrderLine, Guid>
    {
        Task<IEnumerable<OrderLine>> GetOrderLinesByOrderIdAsync(Guid orderId);
    }
}
