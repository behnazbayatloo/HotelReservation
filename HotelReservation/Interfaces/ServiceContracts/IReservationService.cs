using HotelReservation.Dtos;
using HotelReservation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Interfaces.ServiceContracts
{
    public interface IReservationService
    {
        bool  GenerateReserve(DateTime chin, DateTime chout, int userid, int roomid, StatusEnum status);
        List<ShowReservationDto> ShowAll(int customerid);
    }
}
