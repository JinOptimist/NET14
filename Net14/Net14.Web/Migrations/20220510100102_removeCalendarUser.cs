using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class removeCalendarUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysNotes_CalendarUsers_CalendarUserId",
                table: "DaysNotes");
            migrationBuilder.DropTable(
                name: "CalendarUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "DaysNotes");

            migrationBuilder.AddForeignKey(
                name: "FK_DaysNotes_Users_CalendarUserId",
                table: "DaysNotes",
                column: "CalendarUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysNotes_Users_CalendarUserId",
                table: "DaysNotes");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "DaysNotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CalendarUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarUsers", x => x.Id);
                });
        }
    }
}
