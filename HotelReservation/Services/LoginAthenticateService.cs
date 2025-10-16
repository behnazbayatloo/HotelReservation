using HotelReservation.Infrastructure.Repositories;
using HotelReservation.InMemorydb;
using HotelReservation.Interfaces.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services
{
    public class LoginAthenticateService:ILoginAthenticateService
    {
        private readonly UserRepository _userrepository;
        public LoginAthenticateService()
        {
            _userrepository=new UserRepository();
        }

        public bool Login(string username, string password)
        {
            var loginuser = _userrepository.GetLoginUser(username, password);
            if (loginuser != null)
            {
                InMemoryDb.Athenticate(loginuser);
                return true;
            }
            else
                return false;
        }
    }
}
