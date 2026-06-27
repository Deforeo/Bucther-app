using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public class OrderLineRepository : RepositoryBase<OrderLine, Guid>, IOrderLineRepository
    {
        public OrderLineRepository(DatabaseContext context) : base(context) { }

        protected override string GetByIdQuery => "sp_GetOrderLineById";
        protected override string GetAllQuery => "sp_GetAllOrderLines";
        protected override string InsertQuery => "sp_InsertOrderLine";
        protected override string UpdateQuery => "sp_UpdateOrderLine";
        protected override string DeleteQuery => "sp_DeleteOrderLine";

        public async Task<IEnumerable<OrderLine>> GetOrderLinesByOrderIdAsync(Guid orderId)
        {
            var parameters = new { OrderId = orderId };
            return await _context.QueryAsync<OrderLine>("sp_GetOrderLinesByOrder", parameters);
        }
    }
}
