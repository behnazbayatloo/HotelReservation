using HotelReservation.Dtos;
using HotelReservation.Enums;
using HotelReservation.Infrastructure.AppDb;
using HotelReservation.Interfaces.RepositoryContracts;
using HotelReservation.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbCntext _dbcontext;
        public UserRepository()
        {
            _dbcontext=new AppDbCntext();
        }

        public LoginUserDto GetLoginUser(string username,string password)
        {
            return _dbcontext.Users.AsNoTracking().Where(u=> u.UserName==username && u.Password==password)
                .Select(u=> new LoginUserDto
                {
                    Id=u.Id,
                    UserName = u.UserName,
                    Role = u.Role.ToString()
                }).FirstOrDefault();
                
        }
        public List<CustomerDto> GetCustomers()
        {

            return _dbcontext.Users.AsNoTracking().Where(u=>u.Role==RoleEnum.NormalUser)
                .Select(u=> new CustomerDto
                {
                    Id = u.Id,
                    UserName=u.UserName,
                }).ToList();
        }

    }
}
