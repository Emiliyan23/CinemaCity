using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaCity.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingTicketTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingSeats_TicketTypes_TicketTypeId",
                table: "BookingSeats");

            migrationBuilder.AlterColumn<int>(
                name: "TicketTypeId",
                table: "BookingSeats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "BookingTickets",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    TicketTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTickets", x => new { x.BookingId, x.TicketTypeId });
                    table.ForeignKey(
                        name: "FK_BookingTickets_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingTickets_TicketTypes_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingTickets_TicketTypeId",
                table: "BookingTickets",
                column: "TicketTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSeats_TicketTypes_TicketTypeId",
                table: "BookingSeats",
                column: "TicketTypeId",
                principalTable: "TicketTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingSeats_TicketTypes_TicketTypeId",
                table: "BookingSeats");

            migrationBuilder.DropTable(
                name: "BookingTickets");

            migrationBuilder.AlterColumn<int>(
                name: "TicketTypeId",
                table: "BookingSeats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
