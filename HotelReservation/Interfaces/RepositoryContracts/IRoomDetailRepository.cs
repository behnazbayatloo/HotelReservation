using HotelReservation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Interfaces.RepositoryContracts
{
    internal interface IRoomDetailRepository
    {
        int CreateRoomDetail(RoomDetail Detail);
        List<RoomDetail> ShowRoomDetail();
    }
}
