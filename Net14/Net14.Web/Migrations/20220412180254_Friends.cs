using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class Friends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFriendRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    ReceiverId = table.Column<int>(type: "int", nullable: true),
                    FriendRequestStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFriendRequests_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFriendRequests_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSocialUserSocial",
                columns: table => new
                {
                    FriendsId = table.Column<int>(type: "int", nullable: false),
                    WhoFriendsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocialUserSocial", x => new { x.FriendsId, x.WhoFriendsId });
                    table.ForeignKey(
                        name: "FK_UserSocialUserSocial_Users_FriendsId",
                        column: x => x.FriendsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSocialUserSocial_Users_WhoFriendsId",
                        column: x => x.WhoFriendsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFriendRequests_ReceiverId",
                table: "UserFriendRequests",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriendRequests_SenderId",
                table: "UserFriendRequests",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSocialUserSocial_WhoFriendsId",
                table: "UserSocialUserSocial",
                column: "WhoFriendsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFriendRequests");

            migrationBuilder.DropTable(
                name: "UserSocialUserSocial");
        }
    }
}
