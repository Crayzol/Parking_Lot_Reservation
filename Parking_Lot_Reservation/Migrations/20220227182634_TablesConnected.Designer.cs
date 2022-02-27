﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parking_Lot_Reservation.Data;

namespace Parking_Lot_Reservation.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220227182634_TablesConnected")]
    partial class TablesConnected
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Parking_Lot_Reservation.Models.ParkingSpaceModel", b =>
                {
                    b.Property<int>("ParkingSpaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasCharger")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ParkingSpaceId");

                    b.HasIndex("PersonId");

                    b.ToTable("ParkingSpaces");
                });

            modelBuilder.Entity("Parking_Lot_Reservation.Models.PersonModel", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Parking_Lot_Reservation.Models.ParkingSpaceModel", b =>
                {
                    b.HasOne("Parking_Lot_Reservation.Models.PersonModel", "PersonModel")
                        .WithMany("ParkingSpaceModels")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonModel");
                });

            modelBuilder.Entity("Parking_Lot_Reservation.Models.PersonModel", b =>
                {
                    b.Navigation("ParkingSpaceModels");
                });
#pragma warning restore 612, 618
        }
    }
}