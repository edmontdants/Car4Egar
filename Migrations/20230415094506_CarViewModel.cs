using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car4EgarAPI.Migrations
{
    /// <inheritdoc />
    public partial class CarViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarsVM",
                columns: table => new
                {
                    VIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    RatedPeople = table.Column<int>(type: "int", nullable: false),
                    Mailage = table.Column<double>(type: "float", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    AvailableForRent = table.Column<bool>(type: "bit", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationOfRent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPerDay = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insurance = table.Column<bool>(type: "bit", nullable: false),
                    GearBoxType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsVM", x => x.VIN);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsVM");
        }
    }
}
