using HotelReservation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Interfaces.ServiceContracts
{
    public interface IRoomDetailService
    {
        int AddRoomDetail(string description, bool airc, bool wifi);
        List<RoomDetail> ShowRoomDetail();
    }
}
