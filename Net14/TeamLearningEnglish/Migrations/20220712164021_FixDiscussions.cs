using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamLearningEnglish.Migrations
{
    public partial class FixDiscussions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageDiscussionDbModel_TopicDiscussionDbModel_DiscussionId",
                table: "MessageDiscussionDbModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageDiscussionDbModel_User_SenderId",
                table: "MessageDiscussionDbModel");

            migrationBuilder.DropTable(
                name: "TopicDiscussionDbModelUserDbModel");

            migrationBuilder.DropTable(
                name: "TopicsForDiscussion");

            migrationBuilder.DropTable(
                name: "TopicDiscussionDbModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageDiscussionDbModel",
                table: "MessageDiscussionDbModel");

            migrationBuilder.RenameTable(
                name: "MessageDiscussionDbModel",
                newName: "MessagesDiscussion");

            migrationBuilder.RenameIndex(
                name: "IX_MessageDiscussionDbModel_SenderId",
                table: "MessagesDiscussion",
                newName: "IX_MessagesDiscussion_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageDiscussionDbModel_DiscussionId",
                table: "MessagesDiscussion",
                newName: "IX_MessagesDiscussion_DiscussionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessagesDiscussion",
                table: "MessagesDiscussion",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TopicDiscussions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicDiscussions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicDiscussions_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscussionDbModelUserDbModel",
                columns: table => new
                {
                    DisscusionsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussionDbModelUserDbModel", x => new { x.DisscusionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_DiscussionDbModelUserDbModel_TopicDiscussions_DisscusionsId",
                        column: x => x.DisscusionsId,
                        principalTable: "TopicDiscussions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscussionDbModelUserDbModel_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionDbModelUserDbModel_UsersId",
                table: "DiscussionDbModelUserDbModel",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicDiscussions_CreatorId",
                table: "TopicDiscussions",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesDiscussion_TopicDiscussions_DiscussionId",
                table: "MessagesDiscussion",
                column: "DiscussionId",
                principalTable: "TopicDiscussions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesDiscussion_User_SenderId",
                table: "MessagesDiscussion",
                column: "SenderId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessagesDiscussion_TopicDiscussions_DiscussionId",
                table: "MessagesDiscussion");

            migrationBuilder.DropForeignKey(
                name: "FK_MessagesDiscussion_User_SenderId",
                table: "MessagesDiscussion");

            migrationBuilder.DropTable(
                name: "DiscussionDbModelUserDbModel");

            migrationBuilder.DropTable(
                name: "TopicDiscussions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessagesDiscussion",
                table: "MessagesDiscussion");

            migrationBuilder.RenameTable(
                name: "MessagesDiscussion",
                newName: "MessageDiscussionDbModel");

            migrationBuilder.RenameIndex(
                name: "IX_MessagesDiscussion_SenderId",
                table: "MessageDiscussionDbModel",
                newName: "IX_MessageDiscussionDbModel_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_MessagesDiscussion_DiscussionId",
                table: "MessageDiscussionDbModel",
                newName: "IX_MessageDiscussionDbModel_DiscussionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageDiscussionDbModel",
                table: "MessageDiscussionDbModel",
                column: "Id");

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
                name: "TopicsForDiscussion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicsForDiscussion", x => x.Id);
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
                name: "IX_TopicDiscussionDbModelUserDbModel_UsersId",
                table: "TopicDiscussionDbModelUserDbModel",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageDiscussionDbModel_TopicDiscussionDbModel_DiscussionId",
                table: "MessageDiscussionDbModel",
                column: "DiscussionId",
                principalTable: "TopicDiscussionDbModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageDiscussionDbModel_User_SenderId",
                table: "MessageDiscussionDbModel",
                column: "SenderId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
