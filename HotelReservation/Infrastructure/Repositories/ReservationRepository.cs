using HotelReservation.Dtos;
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
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbCntext _dbcontext;
        public ReservationRepository()
        {
            _dbcontext = new AppDbCntext();
        }

        public bool AddReservation(ReservationDto reservation)
        {
            Reservation reserve = new Reservation
            {
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                HotelRoomId = reservation.HotelRoomId,
                Status = reservation.Status,
                UserId= reservation.UserId
            };
            _dbcontext.Reservations.Add(reserve);
            _dbcontext.SaveChanges();
            return true;
     
        }
        public bool IsRoomAvailableAsync(int roomId, DateTime startDate, DateTime endDate)
        {
            return  _dbcontext.Reservations
                .Any(r =>
                    r.RoomId == roomId &&
                    r.CheckInDate < endDate &&
                    r.CheckOutDate > startDate);
        }

        
        public List<ShowReservationDto> GetAll(int customerid)
        {
            return _dbcontext.Reservations.AsNoTracking().Where(r=>r.UserId == customerid)
                .Select(r=> new ShowReservationDto
                {
                    CheckInDate = r.CheckInDate,
                    CheckOutDate = r.CheckOutDate,
                    HotelRoomId= r.HotelRoomId,
                    Status = r.Status,
                    CreatedAt=r.CreatedAt
                    
                }).ToList();

        }
    }
}
