using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Models
{
    public class OrderLine
    {
        public Guid OrderLineId { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        public Guid DishId { get; set; }
        public virtual Dish Dish { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtMoment { get; set; } // цена на момент заказа
        public decimal TotalLine => Quantity * PriceAtMoment;
    }
}
