using HotelReservation.Dtos;
using HotelReservation.Infrastructure.Repositories;
using HotelReservation.Interfaces.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services
{
    public class HotelRoomService:IHotelRoomService
    {
        private readonly HotelRoomRepository _hotel;
        public HotelRoomService()
        {
            _hotel = new HotelRoomRepository();
        }

        public bool AddRoom (CreateRoomDto room)
        {
            return _hotel.CreateRoom(room);
        }
    }
}
