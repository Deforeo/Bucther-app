using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Models
{
    // Связующая таблица для закрепления столов за сменой
    public class ShiftTable
    {
        public Guid ShiftId { get; set; }
        public virtual WorkShift Shift { get; set; }
        public Guid TableId { get; set; }
        public virtual Table Table { get; set; }
    }
}
