using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Models
{
    public class DishCategory
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; } // для порядка отображения кнопок
    }
}
