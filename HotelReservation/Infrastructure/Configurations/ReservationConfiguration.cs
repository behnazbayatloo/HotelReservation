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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r=>r.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
          
            builder.HasOne(r => r.HotelRoom)
                .WithMany(h => h.Reservations)
                .HasForeignKey(h => h.HotelRoomId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(r => r.Status).HasConversion<string>();
            builder.HasIndex(r => new { r.RoomId, r.CheckInDate, r.CheckOutDate });



    }

    }
}
