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
    public class RoomDetailConfiguration : IEntityTypeConfiguration<RoomDetail>
    { 
        public void Configure(EntityTypeBuilder<RoomDetail> builder)
        {
            builder.Property(r => r.Description).HasMaxLength(500);
            builder.HasKey(R=> R.RoomId);
            builder.HasData(new List<RoomDetail>
            {
                new RoomDetail()
                {
                    RoomId=1,
                    Description=@"Ocean Breeze Suite A spacious
corner suite with panoramic sea views,
featuring a king-size bed, private balcony,
rainfall shower, and complimentary minibar.
Perfect for honeymooners or sunset lovers.",HasAirConditioner=true ,HasWifi=true},
                new RoomDetail()
                {
                    RoomId=2,
                    Description=@"Urban Escape Deluxe Modern city-facing 
room with floor-to-ceiling windows,
queen bed, ergonomic workspace, and smart
lighting. Includes access to rooftop 
pool and 24-hour fitness center.",HasAirConditioner=true ,HasWifi=false},
                new RoomDetail()
                {
                    RoomId=3,
                    Description=@"Rustic Mountain Retreat Cozy 
wood-paneled room with fireplace, double bed
, and vintage decor. Offers direct access to 
hiking trails and includes a hearty breakfast
basket delivered each morning.",HasAirConditioner=false ,HasWifi=true},
                new RoomDetail()
                {
                    RoomId=4,
                    Description=@"Zen Garden Studio Minimalist design 
with tatami flooring, low platform bed,
and indoor bonsai corner. Comes with herbal
tea station, yoga mat, and ambient
sound system for relaxation.",HasAirConditioner=true ,HasWifi=true}
            });
        }
    }
}
