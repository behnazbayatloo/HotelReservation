using HotelReservation.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Interfaces.ServiceContracts
{
    public interface IUserService
    {
        List<CustomerDto> ShowAll();
    }
}
