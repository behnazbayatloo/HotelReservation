using HotelReservation.Entities;
using HotelReservation.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u=>u.UserName).HasMaxLength(30).IsRequired();
            builder.Property(u=>u.Password).HasMaxLength(30).IsRequired();
            builder.Property(u => u.Role).HasConversion<string>();
            builder.HasData(new List<User>
            {
                new User () {Id=1,UserName="Admin" ,Password = "12345",Role =RoleEnum.Admin , CreatedAt = new DateTime(1404,07,22,13,32,0) },
                new User () {Id=2,UserName= "Reception",Password="12345",Role=RoleEnum.Receptionist, CreatedAt=new DateTime(1404,07,22,13,32,0)},
                new User () {Id=3,UserName="behnazbayatloo", Password="12345", Role=RoleEnum.NormalUser, CreatedAt= new DateTime(1404,07,22,13,32,0)},
                new User () {Id=4,UserName="meysambeigi" ,Password="12345", Role =RoleEnum.NormalUser,CreatedAt= new DateTime(1404,07,22,13,32,0)},

            });
           
        }
    }
}
