using Bucther_app.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Bucther_app.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime Date { get; set; } // дата создания
        public Guid TableId { get; set; }
        public virtual Table Table { get; set; }
        public Guid? WaiterId { get; set; } // StaffId официанта, создавшего заказ
        public virtual Staff Waiter { get; set; }
        public OrderStatus Status { get; set; } // для зала
        public OrderKitchenStatus KitchenStatus { get; set; } // для кухни
        public decimal TotalAmount { get; set; } // можно вычислять, но для удобства хранить
        public string Comment { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
