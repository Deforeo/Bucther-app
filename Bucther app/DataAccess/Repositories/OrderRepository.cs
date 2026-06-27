using Bucther_app.DataAccess.Helpers;
using Bucther_app.Enum;
using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public class OrderRepository : RepositoryBase<Order, Guid>, IOrderRepository
    {
        public OrderRepository(DatabaseContext context) : base(context) { }

        protected override string GetByIdQuery => "sp_GetOrderById";
        protected override string GetAllQuery => "sp_GetAllOrders";
        protected override string InsertQuery => "sp_InsertOrder";
        protected override string UpdateQuery => "sp_UpdateOrder";
        protected override string DeleteQuery => "sp_DeleteOrder";

        public async Task<Order> CreateOrderAsync(Guid tableId, Guid waiterId)
        {
            var parameters = new { TableId = tableId, WaiterId = waiterId };
            return await SqlExceptionHelper.ExecuteWithErrorHandling(async () =>
            {
                return await _context.QueryFirstOrDefaultAsync<Order>("sp_CreateOrder", parameters);
            });
        }

        public async Task<bool> AddOrderLineAsync(Guid orderId, Guid dishId, int quantity)
        {
            var parameters = new { OrderId = orderId, DishId = dishId, Quantity = quantity };
            return await SqlExceptionHelper.ExecuteWithErrorHandling(async () =>
            {
                var result = await _context.ExecuteAsync("sp_AddOrderLine", parameters);
                return result > 0;
            });
        }

        public async Task<bool> RemoveOrderLineAsync(Guid orderLineId)
        {
            var parameters = new { OrderLineId = orderLineId };
            return await SqlExceptionHelper.ExecuteWithErrorHandling(async () =>
            {
                var result = await _context.ExecuteAsync("sp_RemoveOrderLine", parameters);
                return result > 0;
            });
        }

        public async Task<bool> SubmitOrderAsync(Guid orderId)
        {
            var parameters = new { OrderId = orderId };
            return await SqlExceptionHelper.ExecuteWithErrorHandling(async () =>
            {
                var result = await _context.ExecuteAsync("sp_SubmitOrder", parameters);
                return result > 0;
            });
        }

        public async Task<bool> CancelOrderAsync(Guid orderId)
        {
            var parameters = new { OrderId = orderId };
            return await SqlExceptionHelper.ExecuteWithErrorHandling(async () =>
            {
                var result = await _context.ExecuteAsync("sp_CancelOrder", parameters);
                return result > 0;
            });
        }

        public async Task<bool> UpdateKitchenStatusAsync(Guid orderId, OrderKitchenStatus status)
        {
            var parameters = new { OrderId = orderId, Status = (int)status };
            var result = await _context.ExecuteAsync("sp_UpdateKitchenStatus", parameters);
            return result > 0;
        }

        public async Task<bool> UpdateOrderStatusAsync(Guid orderId, OrderStatus status)
        {
            var parameters = new { OrderId = orderId, Status = (int)status };
            var result = await _context.ExecuteAsync("sp_UpdateOrderStatus", parameters);
            return result > 0;
        }

        public async Task<IEnumerable<Order>> GetOrdersByWaiterAsync(Guid waiterId)
        {
            var parameters = new { WaiterId = waiterId };
            return await _context.QueryAsync<Order>("sp_GetOrdersByWaiter", parameters);
        }

        public async Task<IEnumerable<Order>> GetOrdersByTableAsync(Guid tableId)
        {
            var parameters = new { TableId = tableId };
            return await _context.QueryAsync<Order>("sp_GetOrdersByTable", parameters);
        }

        public async Task<IEnumerable<Order>> GetKitchenOrdersAsync()
        {
            // Возвращаем заказы со статусом "В ожидании" (0) или "Готовится" (1)
            var sql = "sp_GetKitchenOrders";
            return await _context.QueryAsync<Order>(sql);
        }

        public async Task<Order> GetOrderWithDetailsAsync(Guid orderId)
        {
            var parameters = new { OrderId = orderId };
            // Здесь можно использовать несколько запросов для заполнения OrderLines, но для простоты вызовем хранимую процедуру, которая возвращает и заказ, и позиции.
            // В данной реализации я предлагаю получить отдельно заказ и отдельно OrderLines через дополнительный метод.
            // Либо использовать многокарточный запрос Dapper (QueryMultiple).
            // Для простоты я оставлю только заказ, а линии будем получать отдельным репозиторием OrderLineRepository.
            return await _context.QueryFirstOrDefaultAsync<Order>("sp_GetOrderById", parameters);
        }

        public async Task<bool> IsTableHasActiveOrder(Guid tableId)
        {
            var parameters = new { TableId = tableId };
            var result = await _context.QueryFirstOrDefaultAsync<int?>("sp_IsTableHasActiveOrder", parameters);
            return result.HasValue && result.Value > 0;
        }
    }
}
