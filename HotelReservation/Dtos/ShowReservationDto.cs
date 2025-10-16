using HotelReservation.Entities;
using HotelReservation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Dtos
{
    public class ShowReservationDto
    {
        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public StatusEnum Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public int HotelRoomId { get; set; }
    }
}
