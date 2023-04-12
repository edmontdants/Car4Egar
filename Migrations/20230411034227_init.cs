﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car4EgarAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Costes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "money", maxLength: 10, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    NID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Bank_CardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Bank_ExpireDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Bank_CSC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", maxLength: 20480, nullable: true),
                    Balance = table.Column<decimal>(type: "money", maxLength: 10, nullable: false, defaultValue: 0m),
                    Fine = table.Column<decimal>(type: "money", maxLength: 10, nullable: false, defaultValue: 0m),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.NID);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    RentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RentTotalDays = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "money", maxLength: 10, nullable: false, defaultValue: 0m),
                    EndtData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeterStart = table.Column<double>(type: "float", maxLength: 10, nullable: false, defaultValue: 0.0),
                    MeterEnd = table.Column<double>(type: "float", maxLength: 10, nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.RentID);
                });

            migrationBuilder.CreateTable(
                name: "SystemUsers",
                columns: table => new
                {
                    NID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsers", x => x.NID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentID = table.Column<int>(type: "int", nullable: false),
                    SenderID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "money", maxLength: 10, nullable: false, defaultValue: 0m),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeOfTrans = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeOfPay = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TID);
                });

            migrationBuilder.CreateTable(
                name: "AdminRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminRequests_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "AdminID");
                });

            migrationBuilder.CreateTable(
                name: "RentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    BorrowerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BorrowerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedCarVIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentDays = table.Column<int>(type: "int", nullable: false),
                    RequestAcceptance = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentRequests_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "NID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    NID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Bank_CardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Bank_ExpireDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Bank_CSC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", maxLength: 20480, nullable: true),
                    Balance = table.Column<decimal>(type: "money", maxLength: 10, nullable: false, defaultValue: 0m),
                    Fine = table.Column<decimal>(type: "money", maxLength: 10, nullable: false, defaultValue: 0m),
                    Rate = table.Column<double>(type: "float", maxLength: 10, nullable: false, defaultValue: 5.0),
                    RatedPeople = table.Column<int>(type: "int", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    RentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.NID);
                    table.ForeignKey(
                        name: "FK_Borrowers_Rents_RentID",
                        column: x => x.RentID,
                        principalTable: "Rents",
                        principalColumn: "RentID");
                });

            migrationBuilder.CreateTable(
                name: "Cars",
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
                    Year = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                    OwnerNID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    RentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.VIN);
                    table.ForeignKey(
                        name: "FK_Cars_Owners_OwnerNID",
                        column: x => x.OwnerNID,
                        principalTable: "Owners",
                        principalColumn: "NID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Rents_RentID",
                        column: x => x.RentID,
                        principalTable: "Rents",
                        principalColumn: "RentID");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BorrowerNID = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    OwnerNID = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "AdminID");
                    table.ForeignKey(
                        name: "FK_Notifications_Borrowers_BorrowerNID",
                        column: x => x.BorrowerNID,
                        principalTable: "Borrowers",
                        principalColumn: "NID");
                    table.ForeignKey(
                        name: "FK_Notifications_Owners_OwnerNID",
                        column: x => x.OwnerNID,
                        principalTable: "Owners",
                        principalColumn: "NID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminRequests_AdminID",
                table: "AdminRequests",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowers_RentID",
                table: "Borrowers",
                column: "RentID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OwnerNID",
                table: "Cars",
                column: "OwnerNID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RentID",
                table: "Cars",
                column: "RentID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AdminID",
                table: "Notifications",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_BorrowerNID",
                table: "Notifications",
                column: "BorrowerNID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_OwnerNID",
                table: "Notifications",
                column: "OwnerNID");

            migrationBuilder.CreateIndex(
                name: "IX_RentRequests_OwnerId",
                table: "RentRequests",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminRequests");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Costes");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RentRequests");

            migrationBuilder.DropTable(
                name: "SystemUsers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Borrowers");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Rents");
        }
    }
}
