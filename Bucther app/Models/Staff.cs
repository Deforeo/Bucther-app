using Bucther_app.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Models
{
    public class Staff
    {
        public Guid StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PinCode { get; set; } // или пароль (хэш)
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
