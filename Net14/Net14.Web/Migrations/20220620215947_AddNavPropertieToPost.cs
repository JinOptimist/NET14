using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class AddNavPropertieToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplainsSocial_Posts_PostId",
                table: "ComplainsSocial");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainsSocial_Posts_PostId",
                table: "ComplainsSocial",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplainsSocial_Posts_PostId",
                table: "ComplainsSocial");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainsSocial_Posts_PostId",
                table: "ComplainsSocial",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
