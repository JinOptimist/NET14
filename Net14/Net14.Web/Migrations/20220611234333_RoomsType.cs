using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class RoomsType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomGroupName",
                table: "Romms");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Romms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Romms");

            migrationBuilder.AddColumn<string>(
                name: "RoomGroupName",
                table: "Romms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
