using Microsoft.EntityFrameworkCore.Migrations;

namespace AkfnyData.Migrations
{
    public partial class AddUserTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PMPId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PMPId",
                table: "AspNetUsers",
                column: "PMPId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TrainerId",
                table: "AspNetUsers",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PMPs_PMPId",
                table: "AspNetUsers",
                column: "PMPId",
                principalTable: "PMPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Trainers_TrainerId",
                table: "AspNetUsers",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PMPs_PMPId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trainers_TrainerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PMPId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TrainerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PMPId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "AspNetUsers");
        }
    }
}
