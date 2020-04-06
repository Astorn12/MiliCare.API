using Microsoft.EntityFrameworkCore.Migrations;

namespace MiliCare.Migrations
{
    public partial class SensorsMeasuretoaddtowithoudid3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "SensorMeasurments",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "SensorMeasurments");
        }
    }
}
