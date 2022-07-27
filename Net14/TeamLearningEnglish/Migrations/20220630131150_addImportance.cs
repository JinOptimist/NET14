using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamLearningEnglish.Migrations
{
    public partial class addImportance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Words",
                newName: "Importance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Importance",
                table: "Words",
                newName: "Rating");
        }
    }
}
