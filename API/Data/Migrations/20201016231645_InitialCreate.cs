using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    YearsExperience = table.Column<int>(nullable: false),
                    CareerSummary = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ErrorReports",
                columns: table => new
                {
                    ErrorReportId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserSourceUserId = table.Column<int>(nullable: true),
                    Error = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Contents = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorReports", x => x.ErrorReportId);
                    table.ForeignKey(
                        name: "FK_ErrorReports_Users_UserSourceUserId",
                        column: x => x.UserSourceUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LearningResources",
                columns: table => new
                {
                    LearningResourceId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Viewers = table.Column<int>(nullable: false),
                    Placeholder = table.Column<string>(nullable: true),
                    VideoId = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true),
                    AuthorUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningResources", x => x.LearningResourceId);
                    table.ForeignKey(
                        name: "FK_LearningResources_Users_AuthorUserId",
                        column: x => x.AuthorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    ProfileImageUrl = table.Column<string>(nullable: true),
                    Likes = table.Column<int>(nullable: false),
                    Reports = table.Column<int>(nullable: false),
                    Posted = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LearningResourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_LearningResources_LearningResourceId",
                        column: x => x.LearningResourceId,
                        principalTable: "LearningResources",
                        principalColumn: "LearningResourceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    AvatarUrl = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    LearningResourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_LearningResources_LearningResourceId",
                        column: x => x.LearningResourceId,
                        principalTable: "LearningResources",
                        principalColumn: "LearningResourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: true),
                    DatePosted = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    UserIdPostedBy = table.Column<int>(nullable: false),
                    UserPostedByUserId = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Users_UserPostedByUserId",
                        column: x => x.UserPostedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    UserSkillId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    PercentToNextLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => x.UserSkillId);
                    table.ForeignKey(
                        name: "FK_UserSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserPostedByUserId",
                table: "Comment",
                column: "UserPostedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorReports_UserSourceUserId",
                table: "ErrorReports",
                column: "UserSourceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningResources_AuthorUserId",
                table: "LearningResources",
                column: "AuthorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_LearningResourceId",
                table: "Posts",
                column: "LearningResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_LearningResourceId",
                table: "Skills",
                column: "LearningResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillId",
                table: "UserSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserId",
                table: "UserSkill",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "ErrorReports");

            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "LearningResources");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
