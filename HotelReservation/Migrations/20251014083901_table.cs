using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirCondition",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "Wifi",
                table: "HotelRooms");

            migrationBuilder.RenameColumn(
                name: "Test",
                table: "Reservations",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<int>(
                name: "RoomDetailId",
                table: "HotelRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomDetailId",
                table: "HotelRooms",
                column: "RoomDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_RoomDetails_RoomDetailId",
                table: "HotelRooms",
                column: "RoomDetailId",
                principalTable: "RoomDetails",
                principalColumn: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_RoomDetails_RoomDetailId",
                table: "HotelRooms");

            migrationBuilder.DropTable(
                name: "RoomDetails");

            migrationBuilder.DropIndex(
                name: "IX_HotelRooms_RoomDetailId",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "RoomDetailId",
                table: "HotelRooms");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Reservations",
                newName: "Test");

            migrationBuilder.AddColumn<bool>(
                name: "AirCondition",
                table: "HotelRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HotelRooms",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Wifi",
                table: "HotelRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
