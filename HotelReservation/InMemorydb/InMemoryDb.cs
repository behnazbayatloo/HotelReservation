using HotelReservation.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.InMemorydb
{
    public static class InMemoryDb
    {
        public static LoginUserDto CurrentUser { get; set; }
        public static bool IsAthenticate()
        {
            return CurrentUser != null;
        }

        public static void Athenticate(LoginUserDto u)
        {
            CurrentUser = u;
        }
    }
}
