using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaCity.Data.Migrations
{
    /// <inheritdoc />
    public partial class DropTicketTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.DropForeignKey(
		        name: "FK_BookingSeats_TicketTypes_TicketTypeId",
		        table: "BookingSeats");

	        migrationBuilder.DropIndex(
		        name: "IX_BookingSeats_TicketTypeId",
		        table: "BookingSeats");

			migrationBuilder.DropColumn(
		        name: "TicketTypeId",
		        table: "BookingSeats");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.AddColumn<int>(
		        name: "TicketTypeId",
		        table: "BookingSeats",
		        type: "int",
				nullable: true,
		        defaultValue: 0);

	        migrationBuilder.CreateIndex(
		        name: "IX_BookingSeats_TicketTypeId",
		        table: "BookingSeats",
		        column: "TicketTypeId");

	        migrationBuilder.AddForeignKey(
		        name: "FK_BookingSeats_TicketTypes_TicketTypeId",
		        table: "BookingSeats",
		        column: "TicketTypeId",
		        principalTable: "TicketTypes",
		        principalColumn: "Id",
		        onDelete: ReferentialAction.Restrict);
		}
    }
}
