using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class change_model_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervations_Users_UsersId",
                table: "Rezervations");

            migrationBuilder.DropIndex(
                name: "IX_Rezervations_UsersId",
                table: "Rezervations");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Rezervations");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervations_UserId",
                table: "Rezervations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervations_Users_UserId",
                table: "Rezervations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervations_Users_UserId",
                table: "Rezervations");

            migrationBuilder.DropIndex(
                name: "IX_Rezervations_UserId",
                table: "Rezervations");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Rezervations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervations_UsersId",
                table: "Rezervations",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervations_Users_UsersId",
                table: "Rezervations",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
