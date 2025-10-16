using HotelReservation.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Interfaces.RepositoryContracts
{
    public interface IUserRepository
    {
        List<CustomerDto> GetCustomers();
        LoginUserDto GetLoginUser(string username, string password);
    }
}
