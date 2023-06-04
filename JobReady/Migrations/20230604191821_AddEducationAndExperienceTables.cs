using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobReady.Migrations
{
    /// <inheritdoc />
    public partial class AddEducationAndExperienceTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_FileLinks_UserAccounts_CreatedById",
                table: "FileLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_UserAccounts_FollowingId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_UserAccounts_UserAccountId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_JobPosts_JobPostId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_UserAccounts_ApplicantId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_UserAccounts_CreatedById",
                table: "JobPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_JobPosts_JobPostId",
                table: "JobSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Skills_SkillId",
                table: "JobSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_PostEngagements_PostEngagements_CommentId",
                table: "PostEngagements");

            migrationBuilder.DropForeignKey(
                name: "FK_PostEngagements_Posts_PostId",
                table: "PostEngagements");

            migrationBuilder.DropForeignKey(
                name: "FK_PostEngagements_UserAccounts_CreatedById",
                table: "PostEngagements");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_UserAccounts_CreatedById",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_UserAccounts_InstructorId",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_UserAccounts_StudentId",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityMajors_Majors_MajorId",
                table: "UniversityMajors");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityMajors_Universities_UniversityId",
                table: "UniversityMajors");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Industries_IndustryId",
                table: "UserAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Skills_SkillId",
                table: "UserSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_UserAccounts_UserAccountId",
                table: "UserSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSkills",
                table: "UserSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UniversityMajors",
                table: "UniversityMajors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Universities",
                table: "Universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostEngagements",
                table: "PostEngagements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Majors",
                table: "Majors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSkills",
                table: "JobSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPosts",
                table: "JobPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Industries",
                table: "Industries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followers",
                table: "Followers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileLinks",
                table: "FileLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties");

            migrationBuilder.RenameTable(
                name: "UserSkills",
                newName: "UserSkill");

            migrationBuilder.RenameTable(
                name: "UserAccounts",
                newName: "UserAccount");

            migrationBuilder.RenameTable(
                name: "UniversityMajors",
                newName: "UniversityMajor");

            migrationBuilder.RenameTable(
                name: "Universities",
                newName: "University");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "Recommendations",
                newName: "Recommendation");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "PostEngagements",
                newName: "PostEngagement");

            migrationBuilder.RenameTable(
                name: "Majors",
                newName: "Major");

            migrationBuilder.RenameTable(
                name: "JobSkills",
                newName: "JobSkill");

            migrationBuilder.RenameTable(
                name: "JobPosts",
                newName: "JobPost");

            migrationBuilder.RenameTable(
                name: "JobApplications",
                newName: "JobApplication");

            migrationBuilder.RenameTable(
                name: "Industries",
                newName: "Industry");

            migrationBuilder.RenameTable(
                name: "Followers",
                newName: "Follower");

            migrationBuilder.RenameTable(
                name: "FileLinks",
                newName: "FileLink");

            migrationBuilder.RenameTable(
                name: "Faculties",
                newName: "Faculty");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkills_UserAccountId",
                table: "UserSkill",
                newName: "IX_UserSkill_UserAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkill",
                newName: "IX_UserSkill_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccounts_IndustryId",
                table: "UserAccount",
                newName: "IX_UserAccount_IndustryId");

            migrationBuilder.RenameIndex(
                name: "IX_UniversityMajors_UniversityId",
                table: "UniversityMajor",
                newName: "IX_UniversityMajor_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_UniversityMajors_MajorId",
                table: "UniversityMajor",
                newName: "IX_UniversityMajor_MajorId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_StudentId",
                table: "Recommendation",
                newName: "IX_Recommendation_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_InstructorId",
                table: "Recommendation",
                newName: "IX_Recommendation_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CreatedById",
                table: "Post",
                newName: "IX_Post_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_PostEngagements_PostId",
                table: "PostEngagement",
                newName: "IX_PostEngagement_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostEngagements_CreatedById",
                table: "PostEngagement",
                newName: "IX_PostEngagement_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_PostEngagements_CommentId",
                table: "PostEngagement",
                newName: "IX_PostEngagement_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkill",
                newName: "IX_JobSkill_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSkills_JobPostId",
                table: "JobSkill",
                newName: "IX_JobSkill_JobPostId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosts_CreatedById",
                table: "JobPost",
                newName: "IX_JobPost_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_JobPostId",
                table: "JobApplication",
                newName: "IX_JobApplication_JobPostId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_ApplicantId",
                table: "JobApplication",
                newName: "IX_JobApplication_ApplicantId");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_UserAccountId",
                table: "Follower",
                newName: "IX_Follower_UserAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_FollowingId",
                table: "Follower",
                newName: "IX_Follower_FollowingId");

            migrationBuilder.RenameIndex(
                name: "IX_FileLinks_CreatedById",
                table: "FileLink",
                newName: "IX_FileLink_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculty",
                newName: "IX_Faculty_UniversityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSkill",
                table: "UserSkill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UniversityMajor",
                table: "UniversityMajor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_University",
                table: "University",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommendation",
                table: "Recommendation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostEngagement",
                table: "PostEngagement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Major",
                table: "Major",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSkill",
                table: "JobSkill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPost",
                table: "JobPost",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Industry",
                table: "Industry",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follower",
                table: "Follower",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileLink",
                table: "FileLink",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SchoolId = table.Column<long>(type: "bigint", nullable: true),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: true),
                    OtherDegree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MajorId = table.Column<long>(type: "bigint", nullable: true),
                    Grade = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Education_University_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Education_UserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentType = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustryId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationType = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCurrentlyWorking = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experience_Industry_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Experience_UserAccount_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Experience_UserAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_MajorId",
                table: "Education",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_SchoolId",
                table: "Education",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_UserId",
                table: "Education",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_CompanyId",
                table: "Experience",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_IndustryId",
                table: "Experience",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_UserId",
                table: "Experience",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculty_University_UniversityId",
                table: "Faculty",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileLink_UserAccount_CreatedById",
                table: "FileLink",
                column: "CreatedById",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_UserAccount_FollowingId",
                table: "Follower",
                column: "FollowingId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_UserAccount_UserAccountId",
                table: "Follower",
                column: "UserAccountId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_JobPost_JobPostId",
                table: "JobApplication",
                column: "JobPostId",
                principalTable: "JobPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_UserAccount_ApplicantId",
                table: "JobApplication",
                column: "ApplicantId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPost_UserAccount_CreatedById",
                table: "JobPost",
                column: "CreatedById",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkill_JobPost_JobPostId",
                table: "JobSkill",
                column: "JobPostId",
                principalTable: "JobPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkill_Skill_SkillId",
                table: "JobSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_UserAccount_CreatedById",
                table: "Post",
                column: "CreatedById",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEngagement_PostEngagement_CommentId",
                table: "PostEngagement",
                column: "CommentId",
                principalTable: "PostEngagement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEngagement_Post_PostId",
                table: "PostEngagement",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEngagement_UserAccount_CreatedById",
                table: "PostEngagement",
                column: "CreatedById",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendation_UserAccount_InstructorId",
                table: "Recommendation",
                column: "InstructorId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendation_UserAccount_StudentId",
                table: "Recommendation",
                column: "StudentId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityMajor_Major_MajorId",
                table: "UniversityMajor",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityMajor_University_UniversityId",
                table: "UniversityMajor",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_Industry_IndustryId",
                table: "UserAccount",
                column: "IndustryId",
                principalTable: "Industry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_Skill_SkillId",
                table: "UserSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_UserAccount_UserAccountId",
                table: "UserSkill",
                column: "UserAccountId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculty_University_UniversityId",
                table: "Faculty");

            migrationBuilder.DropForeignKey(
                name: "FK_FileLink_UserAccount_CreatedById",
                table: "FileLink");

            migrationBuilder.DropForeignKey(
                name: "FK_Follower_UserAccount_FollowingId",
                table: "Follower");

            migrationBuilder.DropForeignKey(
                name: "FK_Follower_UserAccount_UserAccountId",
                table: "Follower");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_JobPost_JobPostId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_UserAccount_ApplicantId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPost_UserAccount_CreatedById",
                table: "JobPost");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkill_JobPost_JobPostId",
                table: "JobSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkill_Skill_SkillId",
                table: "JobSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserAccount_CreatedById",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_PostEngagement_PostEngagement_CommentId",
                table: "PostEngagement");

            migrationBuilder.DropForeignKey(
                name: "FK_PostEngagement_Post_PostId",
                table: "PostEngagement");

            migrationBuilder.DropForeignKey(
                name: "FK_PostEngagement_UserAccount_CreatedById",
                table: "PostEngagement");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendation_UserAccount_InstructorId",
                table: "Recommendation");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendation_UserAccount_StudentId",
                table: "Recommendation");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityMajor_Major_MajorId",
                table: "UniversityMajor");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityMajor_University_UniversityId",
                table: "UniversityMajor");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_Industry_IndustryId",
                table: "UserAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_Skill_SkillId",
                table: "UserSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_UserAccount_UserAccountId",
                table: "UserSkill");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSkill",
                table: "UserSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccount",
                table: "UserAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UniversityMajor",
                table: "UniversityMajor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_University",
                table: "University");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommendation",
                table: "Recommendation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostEngagement",
                table: "PostEngagement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Major",
                table: "Major");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSkill",
                table: "JobSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPost",
                table: "JobPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Industry",
                table: "Industry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follower",
                table: "Follower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileLink",
                table: "FileLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculty",
                table: "Faculty");

            migrationBuilder.RenameTable(
                name: "UserSkill",
                newName: "UserSkills");

            migrationBuilder.RenameTable(
                name: "UserAccount",
                newName: "UserAccounts");

            migrationBuilder.RenameTable(
                name: "UniversityMajor",
                newName: "UniversityMajors");

            migrationBuilder.RenameTable(
                name: "University",
                newName: "Universities");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "Recommendation",
                newName: "Recommendations");

            migrationBuilder.RenameTable(
                name: "PostEngagement",
                newName: "PostEngagements");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Major",
                newName: "Majors");

            migrationBuilder.RenameTable(
                name: "JobSkill",
                newName: "JobSkills");

            migrationBuilder.RenameTable(
                name: "JobPost",
                newName: "JobPosts");

            migrationBuilder.RenameTable(
                name: "JobApplication",
                newName: "JobApplications");

            migrationBuilder.RenameTable(
                name: "Industry",
                newName: "Industries");

            migrationBuilder.RenameTable(
                name: "Follower",
                newName: "Followers");

            migrationBuilder.RenameTable(
                name: "FileLink",
                newName: "FileLinks");

            migrationBuilder.RenameTable(
                name: "Faculty",
                newName: "Faculties");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkill_UserAccountId",
                table: "UserSkills",
                newName: "IX_UserSkills_UserAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkill_SkillId",
                table: "UserSkills",
                newName: "IX_UserSkills_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccount_IndustryId",
                table: "UserAccounts",
                newName: "IX_UserAccounts_IndustryId");

            migrationBuilder.RenameIndex(
                name: "IX_UniversityMajor_UniversityId",
                table: "UniversityMajors",
                newName: "IX_UniversityMajors_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_UniversityMajor_MajorId",
                table: "UniversityMajors",
                newName: "IX_UniversityMajors_MajorId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendation_StudentId",
                table: "Recommendations",
                newName: "IX_Recommendations_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendation_InstructorId",
                table: "Recommendations",
                newName: "IX_Recommendations_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_PostEngagement_PostId",
                table: "PostEngagements",
                newName: "IX_PostEngagements_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostEngagement_CreatedById",
                table: "PostEngagements",
                newName: "IX_PostEngagements_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_PostEngagement_CommentId",
                table: "PostEngagements",
                newName: "IX_PostEngagements_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CreatedById",
                table: "Posts",
                newName: "IX_Posts_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_JobSkill_SkillId",
                table: "JobSkills",
                newName: "IX_JobSkills_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSkill_JobPostId",
                table: "JobSkills",
                newName: "IX_JobSkills_JobPostId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPost_CreatedById",
                table: "JobPosts",
                newName: "IX_JobPosts_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_JobPostId",
                table: "JobApplications",
                newName: "IX_JobApplications_JobPostId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_ApplicantId",
                table: "JobApplications",
                newName: "IX_JobApplications_ApplicantId");

            migrationBuilder.RenameIndex(
                name: "IX_Follower_UserAccountId",
                table: "Followers",
                newName: "IX_Followers_UserAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Follower_FollowingId",
                table: "Followers",
                newName: "IX_Followers_FollowingId");

            migrationBuilder.RenameIndex(
                name: "IX_FileLink_CreatedById",
                table: "FileLinks",
                newName: "IX_FileLinks_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Faculty_UniversityId",
                table: "Faculties",
                newName: "IX_Faculties_UniversityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSkills",
                table: "UserSkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UniversityMajors",
                table: "UniversityMajors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Universities",
                table: "Universities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostEngagements",
                table: "PostEngagements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Majors",
                table: "Majors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSkills",
                table: "JobSkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPosts",
                table: "JobPosts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Industries",
                table: "Industries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followers",
                table: "Followers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileLinks",
                table: "FileLinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileLinks_UserAccounts_CreatedById",
                table: "FileLinks",
                column: "CreatedById",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_UserAccounts_FollowingId",
                table: "Followers",
                column: "FollowingId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_UserAccounts_UserAccountId",
                table: "Followers",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_JobPosts_JobPostId",
                table: "JobApplications",
                column: "JobPostId",
                principalTable: "JobPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_UserAccounts_ApplicantId",
                table: "JobApplications",
                column: "ApplicantId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_UserAccounts_CreatedById",
                table: "JobPosts",
                column: "CreatedById",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_JobPosts_JobPostId",
                table: "JobSkills",
                column: "JobPostId",
                principalTable: "JobPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Skills_SkillId",
                table: "JobSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEngagements_PostEngagements_CommentId",
                table: "PostEngagements",
                column: "CommentId",
                principalTable: "PostEngagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEngagements_Posts_PostId",
                table: "PostEngagements",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostEngagements_UserAccounts_CreatedById",
                table: "PostEngagements",
                column: "CreatedById",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_UserAccounts_CreatedById",
                table: "Posts",
                column: "CreatedById",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_UserAccounts_InstructorId",
                table: "Recommendations",
                column: "InstructorId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_UserAccounts_StudentId",
                table: "Recommendations",
                column: "StudentId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityMajors_Majors_MajorId",
                table: "UniversityMajors",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityMajors_Universities_UniversityId",
                table: "UniversityMajors",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Industries_IndustryId",
                table: "UserAccounts",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Skills_SkillId",
                table: "UserSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_UserAccounts_UserAccountId",
                table: "UserSkills",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
