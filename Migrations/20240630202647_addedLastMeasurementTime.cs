using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterMonitor.Migrations
{
    /// <inheritdoc />
    public partial class addedLastMeasurementTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastMeasurementRecievedTime",
                table: "Stations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMeasurementRecievedTime",
                table: "Stations");
        }
    }
}
