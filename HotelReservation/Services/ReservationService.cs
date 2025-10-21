using HotelReservation.Dtos;
using HotelReservation.Enums;
using HotelReservation.Infrastructure.Repositories;
using HotelReservation.Interfaces.ServiceContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services
{
    public class ReservationService:IReservationService
    {
        private readonly ReservationRepository _reserv;
        public ReservationService()
        {
            _reserv = new ReservationRepository();
     
        }

        public bool GenerateReserve( DateTime chin,DateTime chout,int userid ,int roomid ,StatusEnum status)
        {
          if (chin<DateTime.Now || chout<DateTime.Now)
            {
                throw new Exception("this date pased.");

            }
          if (chin>chout)
            {
                throw new Exception("checkout date can't earlier than checkin date.");
            }

          bool result=  _reserv.IsRoomAvailableAsync(roomid, chin, chout);
            if (!result)
            {
                var newreserv = new ReservationDto()
                {
                    CheckInDate = chin,
                    CheckOutDate = chout,
                    HotelRoomId = roomid,
                    Status = status,
                    UserId = userid
                };
                return _reserv.AddReservation(newreserv);
            }
            else
            {
                return false;
            }

        }

        public List<ShowReservationDto> ShowAll(int customerid)
        {
            return _reserv.GetAll(customerid);
        }
           
    }
}
