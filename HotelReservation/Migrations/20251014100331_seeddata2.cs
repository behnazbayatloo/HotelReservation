using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class seeddata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1404, 7, 22, 13, 32, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(1404, 7, 22, 13, 32, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(1404, 7, 22, 13, 32, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(1404, 7, 22, 13, 32, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1404, 7, 22, 13, 32, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(1404, 7, 22, 13, 32, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(1404, 7, 22, 13, 32, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(1404, 7, 22, 13, 32, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 13, 28, 57, 629, DateTimeKind.Local).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 13, 28, 57, 630, DateTimeKind.Local).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 13, 28, 57, 630, DateTimeKind.Local).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 13, 28, 57, 630, DateTimeKind.Local).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 13, 28, 57, 633, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 13, 28, 57, 633, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 13, 28, 57, 633, DateTimeKind.Local).AddTicks(9939));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 14, 13, 28, 57, 633, DateTimeKind.Local).AddTicks(9941));
        }
    }
}
