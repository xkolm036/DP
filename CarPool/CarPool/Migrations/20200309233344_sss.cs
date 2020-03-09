using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPool.Migrations
{
    public partial class sss : Migration
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
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
                nullable: false,
                oldClrType: typeof(string),
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
    }
}
