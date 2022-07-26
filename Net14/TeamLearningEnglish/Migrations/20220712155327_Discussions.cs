using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamLearningEnglish.Migrations
{
    public partial class Discussions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TopicDiscussionDbModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicDiscussionDbModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageDiscussionDbModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    DiscussionId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageDiscussionDbModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageDiscussionDbModel_TopicDiscussionDbModel_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "TopicDiscussionDbModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageDiscussionDbModel_User_SenderId",
                        column: x => x.SenderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopicDiscussionDbModelUserDbModel",
                columns: table => new
                {
                    DisscusionsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicDiscussionDbModelUserDbModel", x => new { x.DisscusionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TopicDiscussionDbModelUserDbModel_TopicDiscussionDbModel_DisscusionsId",
                        column: x => x.DisscusionsId,
                        principalTable: "TopicDiscussionDbModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicDiscussionDbModelUserDbModel_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageDiscussionDbModel_DiscussionId",
                table: "MessageDiscussionDbModel",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDiscussionDbModel_SenderId",
                table: "MessageDiscussionDbModel",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicDiscussionDbModelUserDbModel_UsersId",
                table: "TopicDiscussionDbModelUserDbModel",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageDiscussionDbModel");

            migrationBuilder.DropTable(
                name: "TopicDiscussionDbModelUserDbModel");

            migrationBuilder.DropTable(
                name: "TopicDiscussionDbModel");
        }
    }
}
