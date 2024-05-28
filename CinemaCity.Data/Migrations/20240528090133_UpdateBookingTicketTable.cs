using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaCity.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingTicketTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingTickets",
                table: "BookingTickets");

            migrationBuilder.AddColumn<int>(
                name: "BookingTicketId",
                table: "BookingTickets",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BookingTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingTickets",
                table: "BookingTickets",
                column: "BookingTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTickets_BookingId",
                table: "BookingTickets",
                column: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingTickets",
                table: "BookingTickets");

            migrationBuilder.DropIndex(
                name: "IX_BookingTickets_BookingId",
                table: "BookingTickets");

            migrationBuilder.DropColumn(
                name: "BookingTicketId",
                table: "BookingTickets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BookingTickets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingTickets",
                table: "BookingTickets",
                columns: new[] { "BookingId", "TicketTypeId" });
        }
    }
}
