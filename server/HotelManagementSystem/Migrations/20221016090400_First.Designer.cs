﻿// <auto-generated />
using System;
using HotelManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    [DbContext(typeof(HMSApiDbcontext))]
    [Migration("20221016090400_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelManagementSystem.Models.Bill", b =>
                {
                    b.Property<int>("Bill_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Bill_Id"), 1L, 1);

                    b.Property<float>("Bill_Amount")
                        .HasColumnType("real");

                    b.Property<DateTime>("Bill_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Guest_Id")
                        .HasColumnType("int");

                    b.Property<int>("Reservation_Id")
                        .HasColumnType("int");

                    b.HasKey("Bill_Id");

                    b.HasIndex("Reservation_Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Employee", b =>
                {
                    b.Property<int>("Employee_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Employee_Id"), 1L, 1);

                    b.Property<string>("Employee_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Employee_Age")
                        .HasColumnType("int");

                    b.Property<string>("Employee_Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Employee_PhoneNo")
                        .HasColumnType("bigint");

                    b.Property<float>("Employee_Salary")
                        .HasColumnType("real");

                    b.HasKey("Employee_Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Guest", b =>
                {
                    b.Property<int>("Guest_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Guest_Id"), 1L, 1);

                    b.Property<long>("Guest_Aadhar_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Guest_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Guest_Age")
                        .HasColumnType("int");

                    b.Property<string>("Guest_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guest_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Guest_Phone_Number")
                        .HasColumnType("bigint");

                    b.HasKey("Guest_Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Owner", b =>
                {
                    b.Property<int>("Owner_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Owner_Id"), 1L, 1);

                    b.Property<string>("Owner_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Owner_Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Payment_Detail", b =>
                {
                    b.Property<int>("Payment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Payment_Id"), 1L, 1);

                    b.Property<int>("Bill_Id")
                        .HasColumnType("int");

                    b.Property<long>("Payment_Card")
                        .HasColumnType("bigint");

                    b.Property<string>("Payment_Card_Holder_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Payment_Id");

                    b.HasIndex("Bill_Id");

                    b.ToTable("Payment_Details");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Room", b =>
                {
                    b.Property<int>("Room_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Room_Id"), 1L, 1);

                    b.Property<string>("Room_Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Room_Inventory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Room_Price")
                        .HasColumnType("real");

                    b.Property<bool>("Room_Status")
                        .HasColumnType("bit");

                    b.HasKey("Room_Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Room_Reservation", b =>
                {
                    b.Property<int>("Reservation_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Reservation_Id"), 1L, 1);

                    b.Property<int>("Guest_Id")
                        .HasColumnType("int");

                    b.Property<int>("Reservation_No_of_Guests")
                        .HasColumnType("int");

                    b.Property<bool>("Reservation_Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Resevation_Check_In")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Resevation_Check_Out")
                        .HasColumnType("datetime2");

                    b.Property<int>("Room_Id")
                        .HasColumnType("int");

                    b.HasKey("Reservation_Id");

                    b.HasIndex("Guest_Id");

                    b.HasIndex("Room_Id");

                    b.ToTable("Room_Reservations");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Bill", b =>
                {
                    b.HasOne("HotelManagementSystem.Models.Room_Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("Reservation_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Payment_Detail", b =>
                {
                    b.HasOne("HotelManagementSystem.Models.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("Bill_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.Room_Reservation", b =>
                {
                    b.HasOne("HotelManagementSystem.Models.Guest", "Guest")
                        .WithMany()
                        .HasForeignKey("Guest_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagementSystem.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("Room_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });
#pragma warning restore 612, 618
        }
    }
}
