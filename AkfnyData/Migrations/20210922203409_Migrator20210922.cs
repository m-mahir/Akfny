using Microsoft.EntityFrameworkCore.Migrations;

namespace AkfnyData.Migrations
{
    public partial class Migrator20210922 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LecturerId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LecturerId",
                table: "AspNetUsers",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Lecturers_LecturerId",
                table: "AspNetUsers",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Lecturers_LecturerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LecturerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "AspNetUsers");
        }
    }
}
