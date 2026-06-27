using Bucther_app.Enum;
using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.DataAccess.Repositories
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        Task<Order> CreateOrderAsync(Guid tableId, Guid waiterId);
        Task<bool> AddOrderLineAsync(Guid orderId, Guid dishId, int quantity);
        Task<bool> RemoveOrderLineAsync(Guid orderLineId);
        Task<bool> SubmitOrderAsync(Guid orderId); // статус "Оформлен"
        Task<bool> CancelOrderAsync(Guid orderId); // отмена с возвратом на склад
        Task<bool> UpdateKitchenStatusAsync(Guid orderId, OrderKitchenStatus status);
        Task<bool> UpdateOrderStatusAsync(Guid orderId, OrderStatus status);
        Task<IEnumerable<Order>> GetOrdersByWaiterAsync(Guid waiterId);
        Task<IEnumerable<Order>> GetOrdersByTableAsync(Guid tableId);
        Task<IEnumerable<Order>> GetKitchenOrdersAsync(); // со статусами Pending и Cooking
        Task<Order> GetOrderWithDetailsAsync(Guid orderId); // включает OrderLines
        Task<bool> IsTableHasActiveOrder(Guid tableId);
    }
}
