using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryInventory.Migrations
{
    /// <inheritdoc />
    public partial class AddFineAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FineAmount",
                table: "Reservations",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FineAmount",
                table: "Reservations");
        }
    }
}
