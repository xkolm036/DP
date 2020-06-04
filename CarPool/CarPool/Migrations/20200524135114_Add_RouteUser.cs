using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPool.Migrations
{
    public partial class Add_RouteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteUser_route_RouteId",
                table: "RouteUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteUser_AspNetUsers_UserId",
                table: "RouteUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteUser",
                table: "RouteUser");

            migrationBuilder.RenameTable(
                name: "RouteUser",
                newName: "routeUsers");

            migrationBuilder.RenameIndex(
                name: "IX_RouteUser_RouteId",
                table: "routeUsers",
                newName: "IX_routeUsers_RouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_routeUsers",
                table: "routeUsers",
                columns: new[] { "UserId", "RouteId" });

            migrationBuilder.AddForeignKey(
                name: "FK_routeUsers_route_RouteId",
                table: "routeUsers",
                column: "RouteId",
                principalTable: "route",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_routeUsers_AspNetUsers_UserId",
                table: "routeUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_routeUsers_route_RouteId",
                table: "routeUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_routeUsers_AspNetUsers_UserId",
                table: "routeUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_routeUsers",
                table: "routeUsers");

            migrationBuilder.RenameTable(
                name: "routeUsers",
                newName: "RouteUser");

            migrationBuilder.RenameIndex(
                name: "IX_routeUsers_RouteId",
                table: "RouteUser",
                newName: "IX_RouteUser_RouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteUser",
                table: "RouteUser",
                columns: new[] { "UserId", "RouteId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RouteUser_route_RouteId",
                table: "RouteUser",
                column: "RouteId",
                principalTable: "route",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteUser_AspNetUsers_UserId",
                table: "RouteUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
