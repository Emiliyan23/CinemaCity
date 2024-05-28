using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaCity.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBTColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingTicketId",
                table: "BookingTickets",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookingTickets",
                newName: "BookingTicketId");
        }
    }
}
