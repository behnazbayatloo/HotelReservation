using HotelReservation.Entities;
using HotelReservation.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.AppDb
{
    public class AppDbCntext:DbContext
    {
        private readonly string _connectionstring = @"Server=DESKTOP-LO9POA3\SQLEXPRESS;Database=Hotel;Integrated Security = true;Encrypt=True;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionstring);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.ApplyConfiguration(new HotelRoomConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new ReservationConfiguration());

            modelBuilder.ApplyConfiguration(new RoomDetailConfiguration());

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomDetail> RoomDetails { get; set; }
    }
}
