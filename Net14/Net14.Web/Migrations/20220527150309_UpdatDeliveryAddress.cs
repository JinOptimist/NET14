using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class UpdatDeliveryAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "DeliveryAddress",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "DeliveryAddress");
        }
    }
}
