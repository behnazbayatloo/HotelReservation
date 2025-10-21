using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public float PricePerNight { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<Reservation> Reservations { get; set; }

        public RoomDetail RoomDetail { get; set; }  
        public int RoomDetailId { get; set; }
    }
}
