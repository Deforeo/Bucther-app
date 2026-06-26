using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Models
{
    public class Dish
    {
        public Guid DishId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PortionsInStock { get; set; } // складской учет
        public Guid CategoryId { get; set; }
        public virtual DishCategory Category { get; set; }
        public bool IsStopped { get; set; } // для стоп-листа (можно вынести в отдельную таблицу, но упростим)
    }
}
