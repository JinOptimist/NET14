using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamLearningEnglish.Migrations
{
    public partial class AddisActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Words",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "WordComment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "VideoNotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "TopicsForDiscussion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "WordComment");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "VideoNotes");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "User");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "TopicsForDiscussion");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Books");
        }
    }
}
