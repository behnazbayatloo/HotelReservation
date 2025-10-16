﻿using HotelReservation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public StatusEnum Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public HotelRoom HotelRoom { get; set; }
        public int HotelRoomId { get; set; }
    }
}
