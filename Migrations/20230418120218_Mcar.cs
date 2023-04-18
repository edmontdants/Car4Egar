using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car4EgarAPI.Migrations
{
    public partial class Mcar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MCars",
                columns: table => new
                {
                    VIN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Seats = table.Column<int>(type: "int", maxLength: 10, nullable: false, defaultValue: 4),
                    Rate = table.Column<double>(type: "float", maxLength: 10, nullable: false, defaultValue: 5.0),
                    RatedPeople = table.Column<int>(type: "int", nullable: false),
                    Mailage = table.Column<double>(type: "float", maxLength: 20, nullable: false, defaultValue: 0.0),
                    CarType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LicenseEXDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    AvailableForRent = table.Column<bool>(type: "bit", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LocationOfRent = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CostPerDay = table.Column<decimal>(type: "money", maxLength: 10, nullable: false, defaultValue: 0m),
                    Image = table.Column<string>(type: "nvarchar(max)", maxLength: 20480, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Insurance = table.Column<bool>(type: "bit", maxLength: 20, nullable: false),
                    GearBoxType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCars", x => x.VIN);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MCars");
        }
    }
}
