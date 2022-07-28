using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class AddCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialComments_Posts_PostId",
                table: "SocialComments");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialLike_Posts_PostId",
                table: "SocialLike");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialComments_Posts_PostId",
                table: "SocialComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialLike_Posts_PostId",
                table: "SocialLike",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialComments_Posts_PostId",
                table: "SocialComments");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialLike_Posts_PostId",
                table: "SocialLike");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialComments_Posts_PostId",
                table: "SocialComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialLike_Posts_PostId",
                table: "SocialLike",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
