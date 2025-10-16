using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "RoomDetails",
                columns: new[] { "RoomId", "Description", "HasAirConditioner", "HasWifi" },
                values: new object[,]
                {
                    { 1, "Ocean Breeze Suite A spacious\r\ncorner suite with panoramic sea views,\r\nfeaturing a king-size bed, private balcony,\r\nrainfall shower, and complimentary minibar.\r\nPerfect for honeymooners or sunset lovers.", true, true },
                    { 2, "Urban Escape Deluxe Modern city-facing \r\nroom with floor-to-ceiling windows,\r\nqueen bed, ergonomic workspace, and smart\r\nlighting. Includes access to rooftop \r\npool and 24-hour fitness center.", true, false },
                    { 3, "Rustic Mountain Retreat Cozy \r\nwood-paneled room with fireplace, double bed\r\n, and vintage decor. Offers direct access to \r\nhiking trails and includes a hearty breakfast\r\nbasket delivered each morning.", false, true },
                    { 4, "Zen Garden Studio Minimalist design \r\nwith tatami flooring, low platform bed,\r\nand indoor bonsai corner. Comes with herbal\r\ntea station, yoga mat, and ambient\r\nsound system for relaxation.", true, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 14, 13, 28, 57, 633, DateTimeKind.Local).AddTicks(9558), "12345", "Admin", "Admin" },
                    { 2, new DateTime(2025, 10, 14, 13, 28, 57, 633, DateTimeKind.Local).AddTicks(9935), "12345", "Receptionist", "" },
                    { 3, new DateTime(2025, 10, 14, 13, 28, 57, 633, DateTimeKind.Local).AddTicks(9939), "12345", "NormalUser", "behnazbayatloo" },
                    { 4, new DateTime(2025, 10, 14, 13, 28, 57, 633, DateTimeKind.Local).AddTicks(9941), "12345", "NormalUser", "meysambeigi" }
                });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "Id", "Capacity", "CreatedAt", "PricePerNight", "RoomDetailId", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 10, 14, 13, 28, 57, 629, DateTimeKind.Local).AddTicks(1608), 200f, 1, "1" },
                    { 2, 4, new DateTime(2025, 10, 14, 13, 28, 57, 630, DateTimeKind.Local).AddTicks(8619), 300f, 2, "2" },
                    { 3, 2, new DateTime(2025, 10, 14, 13, 28, 57, 630, DateTimeKind.Local).AddTicks(8634), 100f, 3, "3" },
                    { 4, 2, new DateTime(2025, 10, 14, 13, 28, 57, 630, DateTimeKind.Local).AddTicks(8636), 500f, 4, "4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId_CheckInDate_CheckOutDate",
                table: "Reservations",
                columns: new[] { "RoomId", "CheckInDate", "CheckOutDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomId_CheckInDate_CheckOutDate",
                table: "Reservations");

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomDetails",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomDetails",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomDetails",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomDetails",
                keyColumn: "RoomId",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
