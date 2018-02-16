using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeatherApiCore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecast",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityName = table.Column<string>(maxLength: 20, nullable: false),
                    Country = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Week",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Humidity = table.Column<long>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Temp = table.Column<double>(nullable: false),
                    TempMax = table.Column<long>(nullable: false),
                    TempMin = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Week", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Week_Forecast_CityId",
                        column: x => x.CityId,
                        principalTable: "Forecast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Week_CityId",
                table: "Week",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Week");

            migrationBuilder.DropTable(
                name: "Forecast");
        }
    }
}
