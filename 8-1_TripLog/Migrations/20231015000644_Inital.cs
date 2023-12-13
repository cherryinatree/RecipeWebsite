using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _8_1_TripLog.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    TripsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accommodation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccommodationPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccommodationEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThingToDo1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThingToDo2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThingToDo3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.TripsId);
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "TripsId", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Destination", "EndDate", "StartDate", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[] { 1, null, null, null, "Paris", new DateTime(2023, 10, 14, 20, 6, 44, 681, DateTimeKind.Local).AddTicks(944), new DateTime(2023, 10, 14, 20, 6, 44, 681, DateTimeKind.Local).AddTicks(917), "Revolution stuff", "Queen Marie Stuff", "Look at Art" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trip");
        }
    }
}
