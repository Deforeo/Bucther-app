using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Enum
{
    public enum OrderStatus
    {
        Draft = 0,          // Составление
        Submitted = 1,      // Оформлен
        Cancelled = 2,      // Отменен
        ReadyForPickup = 3, // Принят на Выдачу
        Completed = 4       // Выдан
    }
}
