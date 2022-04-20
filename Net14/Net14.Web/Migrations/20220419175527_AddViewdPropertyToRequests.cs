using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class AddViewdPropertyToRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsViewedByReceiver",
                table: "UserFriendRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsViewedBySender",
                table: "UserFriendRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "IsViewedByReceiver",
                table: "UserFriendRequests");

            migrationBuilder.DropColumn(
                name: "IsViewedBySender",
                table: "UserFriendRequests");
        }
    }
}
