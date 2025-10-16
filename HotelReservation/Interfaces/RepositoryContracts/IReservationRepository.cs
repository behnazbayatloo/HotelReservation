using HotelReservation.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Interfaces.RepositoryContracts
{
    public interface IReservationRepository
    {
        bool AddReservation(ReservationDto reservation);
        List<ShowReservationDto> GetAll(int customerid);
        bool IsRoomAvailableAsync(int roomId, DateTime startDate, DateTime endDate);
    }
}
