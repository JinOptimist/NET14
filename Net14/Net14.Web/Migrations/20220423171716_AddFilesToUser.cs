using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class AddFilesToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "fileSocial",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fileSocial_OwnerId",
                table: "fileSocial",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_fileSocial_Users_OwnerId",
                table: "fileSocial",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fileSocial_Users_OwnerId",
                table: "fileSocial");

            migrationBuilder.DropIndex(
                name: "IX_fileSocial_OwnerId",
                table: "fileSocial");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "fileSocial");
        }
    }
}
