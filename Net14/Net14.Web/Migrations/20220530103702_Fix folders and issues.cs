using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class Fixfoldersandissues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdIssue",
                table: "IssuesForToDo");

            migrationBuilder.DropColumn(
                name: "CountIssues",
                table: "FoldersForToDo");

            migrationBuilder.DropColumn(
                name: "IdFolder",
                table: "FoldersForToDo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdIssue",
                table: "IssuesForToDo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountIssues",
                table: "FoldersForToDo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFolder",
                table: "FoldersForToDo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
