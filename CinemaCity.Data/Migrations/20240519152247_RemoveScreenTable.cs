using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaCity.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveScreenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Screens_ScreenId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Screens_ScreenId",
                table: "Showtimes");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.RenameColumn(
                name: "ScreenId",
                table: "Showtimes",
                newName: "CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Showtimes_ScreenId",
                table: "Showtimes",
                newName: "IX_Showtimes_CinemaId");

            migrationBuilder.RenameColumn(
                name: "ScreenId",
                table: "Seats",
                newName: "CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_ScreenId",
                table: "Seats",
                newName: "IX_Seats_CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Cinemas_CinemaId",
                table: "Seats",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Cinemas_CinemaId",
                table: "Showtimes",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Cinemas_CinemaId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Cinemas_CinemaId",
                table: "Showtimes");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Showtimes",
                newName: "ScreenId");

            migrationBuilder.RenameIndex(
                name: "IX_Showtimes_CinemaId",
                table: "Showtimes",
                newName: "IX_Showtimes_ScreenId");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Seats",
                newName: "ScreenId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_CinemaId",
                table: "Seats",
                newName: "IX_Seats_ScreenId");

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screens_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "CinemaId", "Type" },
                values: new object[,]
                {
                    { 1, 1, "2D" },
                    { 2, 2, "2D" },
                    { 3, 3, "2D" },
                    { 4, 1, "3D" },
                    { 5, 2, "3D" },
                    { 6, 3, "3D" },
                    { 7, 2, "4D" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Screens_CinemaId",
                table: "Screens",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Screens_ScreenId",
                table: "Seats",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Screens_ScreenId",
                table: "Showtimes",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
