using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiliCare.Migrations
{
    public partial class Sensorsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorMeasurments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    SensorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorMeasurments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorMeasurments_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorMeasurments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorMeasurments_SensorId",
                table: "SensorMeasurments",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorMeasurments_UserId",
                table: "SensorMeasurments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorMeasurments");

            migrationBuilder.DropTable(
                name: "Sensors");
        }
    }
}
