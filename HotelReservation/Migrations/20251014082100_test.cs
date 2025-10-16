using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomDetail_HasWifi",
                table: "HotelRooms",
                newName: "Wifi");

            migrationBuilder.RenameColumn(
                name: "RoomDetail_HasAirConditioner",
                table: "HotelRooms",
                newName: "AirCondition");

            migrationBuilder.RenameColumn(
                name: "RoomDetail_Description",
                table: "HotelRooms",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "HotelRooms",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wifi",
                table: "HotelRooms",
                newName: "RoomDetail_HasWifi");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "HotelRooms",
                newName: "RoomDetail_Description");

            migrationBuilder.RenameColumn(
                name: "AirCondition",
                table: "HotelRooms",
                newName: "RoomDetail_HasAirConditioner");

            migrationBuilder.AlterColumn<string>(
                name: "RoomDetail_Description",
                table: "HotelRooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
