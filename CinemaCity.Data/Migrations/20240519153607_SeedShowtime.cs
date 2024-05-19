using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaCity.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedShowtime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "CinemaId", "MovieId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 5, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1, new DateTime(2024, 5, 20, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 2, new DateTime(2024, 5, 21, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 3, new DateTime(2024, 5, 21, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, 4, new DateTime(2024, 5, 21, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
