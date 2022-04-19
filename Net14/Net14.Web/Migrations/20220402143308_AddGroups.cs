using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class AddGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupSocialId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupSocial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSocial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupSocialUserSocial",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSocialUserSocial", x => new { x.GroupsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_GroupSocialUserSocial_GroupSocial_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "GroupSocial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupSocialUserSocial_Users_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GroupSocialId",
                table: "Posts",
                column: "GroupSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSocialUserSocial_MembersId",
                table: "GroupSocialUserSocial",
                column: "MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_GroupSocial_GroupSocialId",
                table: "Posts",
                column: "GroupSocialId",
                principalTable: "GroupSocial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_GroupSocial_GroupSocialId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "GroupSocialUserSocial");

            migrationBuilder.DropTable(
                name: "GroupSocial");

            migrationBuilder.DropIndex(
                name: "IX_Posts_GroupSocialId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "GroupSocialId",
                table: "Posts");
        }
    }
}
