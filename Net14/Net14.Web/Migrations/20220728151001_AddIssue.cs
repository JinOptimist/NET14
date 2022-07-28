using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class AddIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueForToDo_FolderForToDo_FolderId",
                table: "IssueForToDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssueForToDo",
                table: "IssueForToDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FolderForToDo",
                table: "FolderForToDo");

            migrationBuilder.RenameTable(
                name: "IssueForToDo",
                newName: "IssuesForToDo");

            migrationBuilder.RenameTable(
                name: "FolderForToDo",
                newName: "FoldersForToDo");

            migrationBuilder.RenameIndex(
                name: "IX_IssueForToDo_FolderId",
                table: "IssuesForToDo",
                newName: "IX_IssuesForToDo_FolderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssuesForToDo",
                table: "IssuesForToDo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoldersForToDo",
                table: "FoldersForToDo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IssuesForToDo_FoldersForToDo_FolderId",
                table: "IssuesForToDo",
                column: "FolderId",
                principalTable: "FoldersForToDo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssuesForToDo_FoldersForToDo_FolderId",
                table: "IssuesForToDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssuesForToDo",
                table: "IssuesForToDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoldersForToDo",
                table: "FoldersForToDo");

            migrationBuilder.RenameTable(
                name: "IssuesForToDo",
                newName: "IssueForToDo");

            migrationBuilder.RenameTable(
                name: "FoldersForToDo",
                newName: "FolderForToDo");

            migrationBuilder.RenameIndex(
                name: "IX_IssuesForToDo_FolderId",
                table: "IssueForToDo",
                newName: "IX_IssueForToDo_FolderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssueForToDo",
                table: "IssueForToDo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FolderForToDo",
                table: "FolderForToDo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueForToDo_FolderForToDo_FolderId",
                table: "IssueForToDo",
                column: "FolderId",
                principalTable: "FolderForToDo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
