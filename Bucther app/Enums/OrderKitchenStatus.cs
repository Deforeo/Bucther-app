using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Enum
{
    // Статус заказа для линии "Кухня"
    public enum OrderKitchenStatus
    {
        Pending = 0,    // В ожидании
        Cooking = 1,    // Готовится
        Ready = 2       // Готов к выдаче
    }
}
