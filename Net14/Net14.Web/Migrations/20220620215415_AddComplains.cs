using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class AddComplains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplainsSocial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    OwnerOfComplainId = table.Column<int>(type: "int", nullable: true),
                    ReasonOfComplain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainsSocial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplainsSocial_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplainsSocial_Users_OwnerOfComplainId",
                        column: x => x.OwnerOfComplainId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplainsSocial_OwnerOfComplainId",
                table: "ComplainsSocial",
                column: "OwnerOfComplainId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainsSocial_PostId",
                table: "ComplainsSocial",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplainsSocial");
        }
    }
}
