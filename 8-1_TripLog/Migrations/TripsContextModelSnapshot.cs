﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _8_1_TripLog.Models;

#nullable disable

namespace _8_1_TripLog.Migrations
{
    [DbContext(typeof(TripsContext))]
    partial class TripsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_8_1_TripLog.Models.Trips", b =>
                {
                    b.Property<int>("TripsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripsId"));

                    b.Property<string>("Accommodation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccommodationEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccommodationPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThingToDo1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThingToDo2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThingToDo3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TripsId");

                    b.ToTable("Trip");

                    b.HasData(
                        new
                        {
                            TripsId = 1,
                            Destination = "Paris",
                            EndDate = new DateTime(2023, 10, 14, 20, 6, 44, 681, DateTimeKind.Local).AddTicks(944),
                            StartDate = new DateTime(2023, 10, 14, 20, 6, 44, 681, DateTimeKind.Local).AddTicks(917),
                            ThingToDo1 = "Revolution stuff",
                            ThingToDo2 = "Queen Marie Stuff",
                            ThingToDo3 = "Look at Art"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
