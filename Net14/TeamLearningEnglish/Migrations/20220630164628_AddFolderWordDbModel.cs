using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamLearningEnglish.Migrations
{
    public partial class AddFolderWordDbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FolderId",
                table: "Words",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FolderWordDbModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passed = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderWordDbModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_FolderId",
                table: "Words",
                column: "FolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_FolderWordDbModel_FolderId",
                table: "Words",
                column: "FolderId",
                principalTable: "FolderWordDbModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_FolderWordDbModel_FolderId",
                table: "Words");

            migrationBuilder.DropTable(
                name: "FolderWordDbModel");

            migrationBuilder.DropIndex(
                name: "IX_Words_FolderId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "Words");
        }
    }
}
