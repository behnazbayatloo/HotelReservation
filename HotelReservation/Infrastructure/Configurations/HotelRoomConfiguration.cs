using HotelReservation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Infrastructure.Configurations
{
    public class HotelRoomConfiguration : IEntityTypeConfiguration<HotelRoom>
    {
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            builder.Property(h=>h.RoomNumber).HasMaxLength(100).IsRequired();

            builder.Property(x=>x.Capacity).IsRequired();

            builder.HasOne(h => h.RoomDetail)
                .WithOne()
                .HasForeignKey<HotelRoom>(h=> h.RoomDetailId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<HotelRoom>()
            {
                new HotelRoom() {Id=1,RoomNumber="1",Capacity=3,PricePerNight=200,CreatedAt=new DateTime(1404,07,22,13,32,0),RoomDetailId=1 },
                new HotelRoom() {Id=2,RoomNumber="2",Capacity=4,PricePerNight=300,CreatedAt=new DateTime(1404,07,22,13,32,0),RoomDetailId=2 },
                 new HotelRoom() {Id=3,RoomNumber="3",Capacity=2,PricePerNight=100,CreatedAt=new DateTime(1404,07,22,13,32,0),RoomDetailId=3 },
                  new HotelRoom() {Id=4,RoomNumber="4",Capacity=2,PricePerNight=500,CreatedAt=new DateTime(1404,07,22,13,32,0),RoomDetailId=4 }

            });
        }
    }
}

//builder.OwnsOne(h => h.RoomDetail, h =>
//{
//    h.Property(h => h.Description).HasColumnName("Description").HasMaxLength(500);
//    h.Property(h => h.HasAirConditioner).HasColumnName("AirCondition");
//    h.Property(h => h.HasWifi).HasColumnName("Wifi");
//});