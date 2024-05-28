using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaCity.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_BookingSeats_TicketTypes_TicketTypeId",
            //    table: "BookingSeats");

            //migrationBuilder.DropIndex(
	        //   name: "IX_BookingSeats_TicketTypeId",
	        //   table: "BookingSeats");

            //migrationBuilder.DropColumn(
            //    name: "TicketTypeId",
            //    table: "BookingSeats");

            migrationBuilder.InsertData(
                table: "BookingSeats",
                columns: new[] { "BookingId", "SeatId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 13 }
                });

            migrationBuilder.InsertData(
                table: "BookingTickets",
                columns: new[] { "Id", "BookingId", "Quantity", "TicketTypeId" },
                values: new object[,]
                {
                    { 1, 1, 3, 1 },
                    { 2, 2, 1, 1 },
                    { 3, 2, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingSeats",
                keyColumns: new[] { "BookingId", "SeatId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BookingSeats",
                keyColumns: new[] { "BookingId", "SeatId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BookingSeats",
                keyColumns: new[] { "BookingId", "SeatId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "BookingSeats",
                keyColumns: new[] { "BookingId", "SeatId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "BookingSeats",
                keyColumns: new[] { "BookingId", "SeatId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "BookingSeats",
                keyColumns: new[] { "BookingId", "SeatId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "BookingTickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookingTickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookingTickets",
                keyColumn: "Id",
                keyValue: 3);

            //migrationBuilder.AddColumn<int>(
            //    name: "TicketTypeId",
            //    table: "BookingSeats",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_BookingSeats_TicketTypeId",
            //    table: "BookingSeats",
            //    column: "TicketTypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_BookingSeats_TicketTypes_TicketTypeId",
            //    table: "BookingSeats",
            //    column: "TicketTypeId",
            //    principalTable: "TicketTypes",
            //    principalColumn: "Id");
        }
    }
}
