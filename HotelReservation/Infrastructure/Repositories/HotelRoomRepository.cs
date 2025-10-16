using HotelReservation.Dtos;
using HotelReservation.Entities;
using HotelReservation.Infrastructure.AppDb;
using HotelReservation.Interfaces.RepositoryContracts;
using HotelReservation.Interfaces.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Repositories
{
    public class HotelRoomRepository:IHotelRoomRepository
    {
        private readonly AppDbCntext _dbcontext;
        public HotelRoomRepository()
        {
            _dbcontext = new AppDbCntext();
        }

        public bool CreateRoom(CreateRoomDto room)
        {
            HotelRoom newroom = new HotelRoom()
            {
                Capacity = room.Capacity,
                PricePerNight = room.PricePerNight,
                RoomDetailId = room.RoomDetailId,
                RoomNumber = room.RoomNumber,
            };
            _dbcontext.HotelRooms.Add(newroom);
            _dbcontext.SaveChanges();
            return true;
        }

    }
}
