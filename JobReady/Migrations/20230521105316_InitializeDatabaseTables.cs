using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobReady.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDatabaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount");

            migrationBuilder.RenameTable(
                name: "UserAccount",
                newName: "UserAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Followers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAccountId = table.Column<long>(type: "bigint", nullable: false),
                    FollowingId = table.Column<long>(type: "bigint", nullable: false),
                    FollowedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsNotificationOn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Followers_UserAccounts_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Followers_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPosts_UserAccounts_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_UserAccounts_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    InstructorId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StudentRequest = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    InstructorReply = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recommendations_UserAccounts_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recommendations_UserAccounts_StudentId",
                        column: x => x.StudentId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<long>(type: "bigint", nullable: false),
                    JobPostId = table.Column<long>(type: "bigint", nullable: false),
                    LetterOfMotivation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AppliedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobApplications_UserAccounts_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostEngagements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    EngagementType = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostEngagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostEngagements_PostEngagements_CommentId",
                        column: x => x.CommentId,
                        principalTable: "PostEngagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostEngagements_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostEngagements_UserAccounts_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobPostId = table.Column<long>(type: "bigint", nullable: false),
                    SkillId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSkills_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAccountId = table.Column<long>(type: "bigint", nullable: false),
                    SkillId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSkills_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FollowingId",
                table: "Followers",
                column: "FollowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_UserAccountId",
                table: "Followers",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_ApplicantId",
                table: "JobApplications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobPostId",
                table: "JobApplications",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_CreatedById",
                table: "JobPosts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_JobPostId",
                table: "JobSkills",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEngagements_CommentId",
                table: "PostEngagements",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEngagements_CreatedById",
                table: "PostEngagements",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PostEngagements_PostId",
                table: "PostEngagements",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatedById",
                table: "Posts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_InstructorId",
                table: "Recommendations",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_StudentId",
                table: "Recommendations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_UserAccountId",
                table: "UserSkills",
                column: "UserAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Followers");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "PostEngagements");

            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "JobPosts");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts");

            migrationBuilder.RenameTable(
                name: "UserAccounts",
                newName: "UserAccount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount",
                column: "Id");
        }
    }
}
