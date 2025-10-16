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
    public class UserService:IUserService
    {
        private readonly UserRepository _user;
        public UserService()
        {
            _user = new UserRepository();
        }
        public List<CustomerDto> ShowAll()
        {
            return _user.GetCustomers();
        }
    }
}
