using Bucther_app.Enum;
using Bucther_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Interfaces
{
    public interface IUserSessionService
    {
        bool IsAuthenticated { get; }
        UserRole? CurrentRole { get; }
        Guid? CurrentUserId { get; }
        Staff CurrentStaff { get; } // если сотрудник
        Client CurrentClient { get; } // если клиент
        Guid? CurrentShiftId { get; set; } // для официанта
        void LoginStaff(Staff staff);
        void LoginClient(Client client);
        void Logout();
        bool HasRole(UserRole role);
    }
}
