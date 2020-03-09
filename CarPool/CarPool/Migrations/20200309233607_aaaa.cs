using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPool.Migrations
{
    public partial class aaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteUser_AppUser_UserId",
                table: "RouteUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteUser",
                table: "RouteUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RouteUser",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteUser",
                table: "RouteUser",
                columns: new[] { "RoutId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RouteUser_AppUser_UserId",
                table: "RouteUser",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteUser_AppUser_UserId",
                table: "RouteUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteUser",
                table: "RouteUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RouteUser",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteUser",
                table: "RouteUser",
                column: "RoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_RouteUser_AppUser_UserId",
                table: "RouteUser",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
