using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car4EgarAPI.Migrations
{
    /// <inheritdoc />
    public partial class CarViewModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableForRent",
                table: "CarsVM",
                newName: "Available");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Available",
                table: "CarsVM",
                newName: "AvailableForRent");
        }
    }
}
