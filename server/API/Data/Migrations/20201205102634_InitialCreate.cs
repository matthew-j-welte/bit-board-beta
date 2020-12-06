using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AvatarUrl = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    BgColorHex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    YearsExperience = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TechnicalSummary = table.Column<string>(nullable: true),
                    CurrentEmployer = table.Column<string>(nullable: true),
                    YearsAtEmployer = table.Column<int>(nullable: false),
                    JobDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CodeEditorConfiguration",
                columns: table => new
                {
                    CodeEditorConfigurationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FontSize = table.Column<int>(nullable: false),
                    TabSize = table.Column<int>(nullable: false),
                    ColorTheme = table.Column<string>(nullable: true),
                    ColorThemeUrl = table.Column<string>(nullable: true),
                    HasGutter = table.Column<bool>(nullable: false),
                    HasLineNumbers = table.Column<bool>(nullable: false),
                    HighlightLine = table.Column<bool>(nullable: false),
                    EditorHeight = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeEditorConfiguration", x => x.CodeEditorConfigurationId);
                    table.ForeignKey(
                        name: "FK_CodeEditorConfiguration_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErrorReport",
                columns: table => new
                {
                    ErrorReportId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserSourceUserId = table.Column<int>(nullable: true),
                    Error = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Contents = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorReport", x => x.ErrorReportId);
                    table.ForeignKey(
                        name: "FK_ErrorReport_User_UserSourceUserId",
                        column: x => x.UserSourceUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LearningResource",
                columns: table => new
                {
                    LearningResourceId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Viewers = table.Column<int>(nullable: false),
                    Placeholder = table.Column<string>(nullable: true),
                    VideoId = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningResource", x => x.LearningResourceId);
                    table.ForeignKey(
                        name: "FK_LearningResource_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningResourceSuggestion",
                columns: table => new
                {
                    LearningResourceSuggestionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    SourceUrl = table.Column<string>(nullable: true),
                    Rationale = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningResourceSuggestion", x => x.LearningResourceSuggestionId);
                    table.ForeignKey(
                        name: "FK_LearningResourceSuggestion_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    UserSkillId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ProgressPercent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => x.UserSkillId);
                    table.ForeignKey(
                        name: "FK_UserSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningResourceSkill",
                columns: table => new
                {
                    LearningResourceSkillId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LearningResourceId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningResourceSkill", x => x.LearningResourceSkillId);
                    table.ForeignKey(
                        name: "FK_LearningResourceSkill_LearningResource_LearningResourceId",
                        column: x => x.LearningResourceId,
                        principalTable: "LearningResource",
                        principalColumn: "LearningResourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningResourceSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Likes = table.Column<int>(nullable: false),
                    Reports = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LearningResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_LearningResource_LearningResourceId",
                        column: x => x.LearningResourceId,
                        principalTable: "LearningResource",
                        principalColumn: "LearningResourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserResourceState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    ProgressPercent = table.Column<int>(nullable: false),
                    LearningResourceId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResourceState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserResourceState_LearningResource_LearningResourceId",
                        column: x => x.LearningResourceId,
                        principalTable: "LearningResource",
                        principalColumn: "LearningResourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserResourceState_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningResourceSuggestionSkill",
                columns: table => new
                {
                    LearningResourceSuggestionSkillId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LearningResourceSuggestionId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningResourceSuggestionSkill", x => x.LearningResourceSuggestionSkillId);
                    table.ForeignKey(
                        name: "FK_LearningResourceSuggestionSkill_LearningResourceSuggestion_LearningResourceSuggestionId",
                        column: x => x.LearningResourceSuggestionId,
                        principalTable: "LearningResourceSuggestion",
                        principalColumn: "LearningResourceSuggestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningResourceSuggestionSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPostRelationship",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserPostAction = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    LearningResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPostRelationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPostRelationship_LearningResource_LearningResourceId",
                        column: x => x.LearningResourceId,
                        principalTable: "LearningResource",
                        principalColumn: "LearningResourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPostRelationship_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPostRelationship_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeEditorConfiguration_UserId",
                table: "CodeEditorConfiguration",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorReport_UserSourceUserId",
                table: "ErrorReport",
                column: "UserSourceUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningResource_UserId",
                table: "LearningResource",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningResourceSkill_LearningResourceId",
                table: "LearningResourceSkill",
                column: "LearningResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningResourceSkill_SkillId",
                table: "LearningResourceSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningResourceSuggestion_UserId",
                table: "LearningResourceSuggestion",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningResourceSuggestionSkill_LearningResourceSuggestionId",
                table: "LearningResourceSuggestionSkill",
                column: "LearningResourceSuggestionId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningResourceSuggestionSkill_SkillId",
                table: "LearningResourceSuggestionSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_LearningResourceId",
                table: "Post",
                column: "LearningResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostRelationship_LearningResourceId",
                table: "UserPostRelationship",
                column: "LearningResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostRelationship_PostId",
                table: "UserPostRelationship",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostRelationship_UserId",
                table: "UserPostRelationship",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResourceState_LearningResourceId",
                table: "UserResourceState",
                column: "LearningResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResourceState_UserId",
                table: "UserResourceState",
                column: "UserId");

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
                name: "CodeEditorConfiguration");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "ErrorReport");

            migrationBuilder.DropTable(
                name: "LearningResourceSkill");

            migrationBuilder.DropTable(
                name: "LearningResourceSuggestionSkill");

            migrationBuilder.DropTable(
                name: "UserPostRelationship");

            migrationBuilder.DropTable(
                name: "UserResourceState");

            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropTable(
                name: "LearningResourceSuggestion");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "LearningResource");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
