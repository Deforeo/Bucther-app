using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Models
{
    public class Table
    {
        public Guid TableId { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; } // до 4 человек
        public Guid ZoneId { get; set; }
        public virtual Zone Zone { get; set; } // для навигации (не обязательно в DTO)
    }
}
