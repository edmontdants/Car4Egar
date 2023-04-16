using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car4EgarAPI.Migrations
{
    /// <inheritdoc />
    public partial class edit_sysUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "SystemUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "SystemUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "SystemUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "SystemUsers");
        }
    }
}
