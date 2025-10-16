using HotelReservation.Entities;
using HotelReservation.Infrastructure.AppDb;
using HotelReservation.Interfaces.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Repositories
{
    public class RoomDetailRepository:IRoomDetailRepository
    {
        private readonly AppDbCntext _dbcontext;
        public RoomDetailRepository()
        {
            _dbcontext = new AppDbCntext();
        }

        public int CreateRoomDetail(RoomDetail Detail)
        {
            _dbcontext.RoomDetails.Add(Detail);
            _dbcontext.SaveChanges();
            return Detail.RoomId;
        }


        public List<RoomDetail> ShowRoomDetail()
        {
            return _dbcontext.RoomDetails.AsNoTracking().ToList();
        }
    }
}
