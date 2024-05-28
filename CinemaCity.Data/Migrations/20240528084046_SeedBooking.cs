using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaCity.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "ShowtimeId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 28, 11, 36, 12, 0, DateTimeKind.Unspecified), 1, "acc2665f-25bd-43f8-87e5-6027c253b3cc" },
                    { 2, new DateTime(2024, 5, 28, 11, 40, 12, 0, DateTimeKind.Unspecified), 1, "acc2665f-25bd-43f8-87e5-6027c253b3cc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
