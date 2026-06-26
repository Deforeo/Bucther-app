using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Models
{
    public class Zone
    {
        public Guid ZoneId { get; set; }
        public string Name { get; set; } // например, "Зал 1", "Терраса"
        public string Description { get; set; }
    }
}
