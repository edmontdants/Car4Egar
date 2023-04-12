﻿// <auto-generated />
using System;
using Car4EgarAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Car4EgarAPI.Migrations
{
    [DbContext(typeof(Car4EgarContext))]
    partial class Car4EgarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Admin", b =>
                {
                    b.Property<string>("AdminID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.AdminRequest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdminID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DocumentSource")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminID");

                    b.ToTable("AdminRequests");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Borrower", b =>
                {
                    b.Property<string>("NID")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.Property<string>("Bank_CSC")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Bank_CardNumber")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Bank_ExpireDate")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Fine")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Photo")
                        .HasMaxLength(20480)
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("float")
                        .HasDefaultValue(5.0);

                    b.Property<int>("RatedPeople")
                        .HasColumnType("int");

                    b.Property<int?>("RentID")
                        .HasColumnType("int");

                    b.HasKey("NID");

                    b.HasIndex("RentID");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Car", b =>
                {
                    b.Property<string>("VIN")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("AvailableForRent")
                        .IsUnicode(true)
                        .HasColumnType("bit");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("CostPerDay")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.Property<string>("GearBoxType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Image")
                        .HasMaxLength(20480)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Insurance")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("bit");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LicenseEXDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LocationOfRent")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("Mailage")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("OwnerNID")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("Rate")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("float")
                        .HasDefaultValue(5.0);

                    b.Property<int>("RatedPeople")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RentID")
                        .HasColumnType("int");

                    b.Property<int>("Seats")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .IsUnicode(true)
                        .HasColumnType("int")
                        .HasDefaultValue(4);

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("VIN");

                    b.HasIndex("OwnerNID");

                    b.HasIndex("RentID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Costes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Costes");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BorrowerNID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerNID")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminID");

                    b.HasIndex("BorrowerNID");

                    b.HasIndex("OwnerNID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Owner", b =>
                {
                    b.Property<string>("NID")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.Property<string>("Bank_CSC")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Bank_CardNumber")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Bank_ExpireDate")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Fine")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Photo")
                        .HasMaxLength(20480)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Rent", b =>
                {
                    b.Property<int>("RentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentID"));

                    b.Property<DateTime?>("ActualEndData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndtData")
                        .HasColumnType("datetime2");

                    b.Property<double>("MeterEnd")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("MeterStart")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<int>("RentTotalDays")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("TotalAmount")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.HasKey("RentID");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.RentRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BorrowerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BorrowerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BorrowerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RentDays")
                        .HasColumnType("int");

                    b.Property<bool>("RequestAcceptance")
                        .HasColumnType("bit");

                    b.Property<string>("RequestedCarVIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("RentRequests");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.SystemUser", b =>
                {
                    b.Property<string>("NID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("NID");

                    b.ToTable("SystemUsers");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Transaction", b =>
                {
                    b.Property<int>("TID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TID"));

                    b.Property<decimal>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("RecieverID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentID")
                        .HasColumnType("int");

                    b.Property<string>("SenderID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfPay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfTrans")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("TID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.AdminRequest", b =>
                {
                    b.HasOne("Car4EgarAPI.Models.Entities.Admin", null)
                        .WithMany("AdminRequests")
                        .HasForeignKey("AdminID");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Borrower", b =>
                {
                    b.HasOne("Car4EgarAPI.Models.Entities.Rent", "Rent")
                        .WithMany("Borrower")
                        .HasForeignKey("RentID");

                    b.Navigation("Rent");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Car", b =>
                {
                    b.HasOne("Car4EgarAPI.Models.Entities.Owner", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerNID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car4EgarAPI.Models.Entities.Rent", "Rent")
                        .WithMany("Cars")
                        .HasForeignKey("RentID");

                    b.Navigation("Owner");

                    b.Navigation("Rent");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Notification", b =>
                {
                    b.HasOne("Car4EgarAPI.Models.Entities.Admin", null)
                        .WithMany("Notifications")
                        .HasForeignKey("AdminID");

                    b.HasOne("Car4EgarAPI.Models.Entities.Borrower", null)
                        .WithMany("Notifications")
                        .HasForeignKey("BorrowerNID");

                    b.HasOne("Car4EgarAPI.Models.Entities.Owner", null)
                        .WithMany("Notifications")
                        .HasForeignKey("OwnerNID");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.RentRequest", b =>
                {
                    b.HasOne("Car4EgarAPI.Models.Entities.Owner", null)
                        .WithMany("OwnerRequests")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Admin", b =>
                {
                    b.Navigation("AdminRequests");

                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Borrower", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Owner", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Notifications");

                    b.Navigation("OwnerRequests");
                });

            modelBuilder.Entity("Car4EgarAPI.Models.Entities.Rent", b =>
                {
                    b.Navigation("Borrower");

                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
