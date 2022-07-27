using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamLearningEnglish.Migrations
{
    public partial class DeleteNoticeForVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordComment_Words_WordId",
                table: "WordComment");

            migrationBuilder.DropTable(
                name: "VideoNotes");

            migrationBuilder.AddForeignKey(
                name: "FK_WordComment_Words_WordId",
                table: "WordComment",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordComment_Words_WordId",
                table: "WordComment");

            migrationBuilder.CreateTable(
                name: "VideoNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoNotes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WordComment_Words_WordId",
                table: "WordComment",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
