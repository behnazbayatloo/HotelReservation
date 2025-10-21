using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomDetails",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HasWifi = table.Column<bool>(type: "bit", nullable: false),
                    HasAirConditioner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDetails", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRooms_RoomDetails_RoomDetailId",
                        column: x => x.RoomDetailId,
                        principalTable: "RoomDetails",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HotelRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_HotelRooms_HotelRoomId",
                        column: x => x.HotelRoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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
                    { 1, new DateTime(2025, 10, 17, 13, 32, 0, 0, DateTimeKind.Unspecified), "12345", "Admin", "Admin" },
                    { 2, new DateTime(2025, 10, 17, 13, 32, 0, 0, DateTimeKind.Unspecified), "12345", "Receptionist", "Reception" },
                    { 3, new DateTime(2025, 10, 17, 13, 32, 0, 0, DateTimeKind.Unspecified), "12345", "NormalUser", "behnazbayatloo" },
                    { 4, new DateTime(2025, 10, 17, 13, 32, 0, 0, DateTimeKind.Unspecified), "12345", "NormalUser", "meysambeigi" }
                });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "Id", "Capacity", "CreatedAt", "PricePerNight", "RoomDetailId", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 10, 17, 13, 32, 0, 0, DateTimeKind.Unspecified), 200f, 1, "1" },
                    { 2, 4, new DateTime(2025, 10, 17, 13, 32, 0, 0, DateTimeKind.Unspecified), 300f, 2, "2" },
                    { 3, 2, new DateTime(2025, 10, 17, 13, 32, 0, 0, DateTimeKind.Unspecified), 100f, 3, "3" },
                    { 4, 2, new DateTime(2025, 10, 17, 13, 32, 0, 0, DateTimeKind.Unspecified), 500f, 4, "4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomDetailId",
                table: "HotelRooms",
                column: "RoomDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HotelRoomId",
                table: "Reservations",
                column: "HotelRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId_CheckInDate_CheckOutDate",
                table: "Reservations",
                columns: new[] { "RoomId", "CheckInDate", "CheckOutDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RoomDetails");
        }
    }
}
