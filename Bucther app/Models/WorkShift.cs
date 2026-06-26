using Bucther_app.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Models
{
    public class WorkShift
    {
        public Guid ShiftId { get; set; }
        public Guid StaffId { get; set; } // официант
        public virtual Staff Staff { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ShiftStatus Status { get; set; } // Opened, Closed
        public string ZoneName { get; set; } // зона, закреплённая за сменой (можно хранить или получать через shift_tables)
        public DateTime CreatedAt { get; set; }
    }
}
