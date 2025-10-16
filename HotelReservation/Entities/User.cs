using HotelReservation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;

        public List<Reservation> Reservations { get; set; }

    }
}
