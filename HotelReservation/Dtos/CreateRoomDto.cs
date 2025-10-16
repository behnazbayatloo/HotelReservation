using HotelReservation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Dtos
{
    public class CreateRoomDto
    {
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public float PricePerNight { get; set; }
      
        public int RoomDetailId { get; set; }

    }
}
