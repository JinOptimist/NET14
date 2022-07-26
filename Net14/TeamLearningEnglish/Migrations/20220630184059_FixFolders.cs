using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamLearningEnglish.Migrations
{
    public partial class FixFolders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_FolderWordDbModel_FolderId",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FolderWordDbModel",
                table: "FolderWordDbModel");

            migrationBuilder.RenameTable(
                name: "FolderWordDbModel",
                newName: "FolderWord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FolderWord",
                table: "FolderWord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_FolderWord_FolderId",
                table: "Words",
                column: "FolderId",
                principalTable: "FolderWord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_FolderWord_FolderId",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FolderWord",
                table: "FolderWord");

            migrationBuilder.RenameTable(
                name: "FolderWord",
                newName: "FolderWordDbModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FolderWordDbModel",
                table: "FolderWordDbModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_FolderWordDbModel_FolderId",
                table: "Words",
                column: "FolderId",
                principalTable: "FolderWordDbModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
