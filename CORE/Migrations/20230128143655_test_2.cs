using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CORE.Migrations
{
    public partial class test_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Point_PointId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PointId",
                table: "AspNetUsers",
                newName: "pointId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_PointId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_pointId");

            migrationBuilder.AddColumn<string>(
                name: "EmailVerifyToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassResetToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Point_pointId",
                table: "AspNetUsers",
                column: "pointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Point_pointId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailVerifyToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PassResetToken",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "pointId",
                table: "AspNetUsers",
                newName: "PointId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_pointId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_PointId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Point_PointId",
                table: "AspNetUsers",
                column: "PointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
