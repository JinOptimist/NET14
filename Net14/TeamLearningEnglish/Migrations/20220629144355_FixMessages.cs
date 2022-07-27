using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamLearningEnglish.Migrations
{
    public partial class FixMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_UserDbModelId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserDbModelId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserDbModelId",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDbModelId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserDbModelId",
                table: "User",
                column: "UserDbModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_UserDbModelId",
                table: "User",
                column: "UserDbModelId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
