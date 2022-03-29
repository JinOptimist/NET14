using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Net14.Web.Migrations
{
    public partial class FixUserSocial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserSocialId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "settingsId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "socialId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Social",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Social", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    socialId = table.Column<int>(type: "int", nullable: true),
                    settingsId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Social_socialId",
                        column: x => x.socialId,
                        principalTable: "Social",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserSettings_settingsId",
                        column: x => x.settingsId,
                        principalTable: "UserSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_settingsId",
                table: "Users",
                column: "settingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_socialId",
                table: "Users",
                column: "socialId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSocialId",
                table: "Users",
                column: "UserSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_User_settingsId",
                table: "User",
                column: "settingsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_socialId",
                table: "User",
                column: "socialId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                table: "User",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Social_socialId",
                table: "Users",
                column: "socialId",
                principalTable: "Social",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserSocialId",
                table: "Users",
                column: "UserSocialId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserSettings_settingsId",
                table: "Users",
                column: "settingsId",
                principalTable: "UserSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Social_socialId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserSocialId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserSettings_settingsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Social");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropIndex(
                name: "IX_Users_settingsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_socialId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserSocialId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserSocialId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "settingsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "socialId",
                table: "Users");
        }
    }
}
