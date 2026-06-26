using Bucther_app.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Models
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public Guid TableId { get; set; }
        public virtual Table Table { get; set; }
        public DateTime ResTime { get; set; } // время брони
        public int GuestsCount { get; set; } // количество гостей
        public string Comment { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
