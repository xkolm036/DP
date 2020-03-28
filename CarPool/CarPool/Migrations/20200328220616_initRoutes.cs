using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPool.Migrations
{
    public partial class initRoutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "route",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startdestination = table.Column<string>(nullable: false),
                    finaldestination = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    seats = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "routeUsers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    RoutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routeUsers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "route");

            migrationBuilder.DropTable(
                name: "routeUsers");
        }
    }
}
