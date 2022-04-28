using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class CalendarUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysNotes_Days_DaysId",
                table: "DaysNotes");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.RenameColumn(
                name: "DaysId",
                table: "DaysNotes",
                newName: "CalendarUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DaysNotes_DaysId",
                table: "DaysNotes",
                newName: "IX_DaysNotes_CalendarUserId");

            migrationBuilder.CreateTable(
                name: "CalendarUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarUsers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DaysNotes_CalendarUsers_CalendarUserId",
                table: "DaysNotes",
                column: "CalendarUserId",
                principalTable: "CalendarUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysNotes_CalendarUsers_CalendarUserId",
                table: "DaysNotes");

            migrationBuilder.DropTable(
                name: "CalendarUsers");

            migrationBuilder.RenameColumn(
                name: "CalendarUserId",
                table: "DaysNotes",
                newName: "DaysId");

            migrationBuilder.RenameIndex(
                name: "IX_DaysNotes_CalendarUserId",
                table: "DaysNotes",
                newName: "IX_DaysNotes_DaysId");

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHoliday = table.Column<bool>(type: "bit", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DaysNotes_Days_DaysId",
                table: "DaysNotes",
                column: "DaysId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
