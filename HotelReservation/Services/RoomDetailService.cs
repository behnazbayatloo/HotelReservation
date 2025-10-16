using HotelReservation.Entities;
using HotelReservation.Infrastructure.Repositories;
using HotelReservation.Interfaces.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services
{
    public class RoomDetailService:IRoomDetailService
    {
        private readonly RoomDetailRepository _room;
        public RoomDetailService()
        {
            _room = new RoomDetailRepository();
        }

        public List<RoomDetail> ShowRoomDetail()
        {
            return _room.ShowRoomDetail();
        }

        public int  AddRoomDetail(string description, bool airc, bool wifi)
        {
            RoomDetail roomDetail = new RoomDetail()
            {
                Description = description,
                HasAirConditioner = airc,
                HasWifi=wifi
            };
            return _room.CreateRoomDetail(roomDetail);
        }
    }
}
