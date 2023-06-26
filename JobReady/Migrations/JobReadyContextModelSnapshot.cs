﻿// <auto-generated />
using System;
using JobReady;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobReady.Migrations
{
    [DbContext(typeof(JobReadyContext))]
    partial class JobReadyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobReady.Configuration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("PrivateKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Configuration");
                });

            modelBuilder.Entity("JobReady.Education", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("Degree")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("FieldOfStudy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Grade")
                        .HasColumnType("bigint");

                    b.Property<long?>("MajorId")
                        .HasColumnType("bigint");

                    b.Property<string>("OtherDegree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SchoolId")
                        .HasColumnType("bigint");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.HasIndex("SchoolId");

                    b.HasIndex("UserId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("JobReady.Experience", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmploymentType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("IndustryId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsCurrentlyWorking")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationType")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("IndustryId");

                    b.HasIndex("UserId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("JobReady.Faculty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BranchLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("BranchNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("JobReady.FileLink", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte[]>("ContentHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("ContentSize")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ObjectId")
                        .HasColumnType("bigint");

                    b.Property<int?>("ObjectType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("FileLink");
                });

            modelBuilder.Entity("JobReady.Follower", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("FollowedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FollowingId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsNotificationOn")
                        .HasColumnType("bit");

                    b.Property<string>("UserAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FollowingId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("Follower");
                });

            modelBuilder.Entity("JobReady.Industry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Industry");
                });

            modelBuilder.Entity("JobReady.JobApplication", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ApplicantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AppliedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("JobPostId")
                        .HasColumnType("bigint");

                    b.Property<string>("LetterOfMotivation")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("JobPostId");

                    b.ToTable("JobApplication");
                });

            modelBuilder.Entity("JobReady.JobPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsRemote")
                        .HasColumnType("bit");

                    b.Property<int>("JobType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("JobPost");
                });

            modelBuilder.Entity("JobReady.JobSkill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("JobPostId")
                        .HasColumnType("bigint");

                    b.Property<long>("SkillId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("JobPostId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobSkill");
                });

            modelBuilder.Entity("JobReady.Major", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Major");
                });

            modelBuilder.Entity("JobReady.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("JobReady.PostEngagement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CommentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("EngagementType")
                        .HasColumnType("int");

                    b.Property<long>("PostId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PostId");

                    b.ToTable("PostEngagement");
                });

            modelBuilder.Entity("JobReady.Recommendation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("InstructorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InstructorReply")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime?>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.HasIndex("StudentId");

                    b.ToTable("Recommendation");
                });

            modelBuilder.Entity("JobReady.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("JobReady.University", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BranchesCount")
                        .HasColumnType("bigint");

                    b.Property<string>("HeadQuarterLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("University");
                });

            modelBuilder.Entity("JobReady.UniversityMajor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("MajorId")
                        .HasColumnType("bigint");

                    b.Property<long>("UniversityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.HasIndex("UniversityId");

                    b.ToTable("UniversityMajor");
                });

            modelBuilder.Entity("JobReady.UserAccount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Headline")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long?>("IndustryId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UserDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IndustryId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("JobReady.UserSkill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("SkillId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("UserSkill");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JobReady.Education", b =>
                {
                    b.HasOne("JobReady.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JobReady.University", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JobReady.UserAccount", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Major");

                    b.Navigation("School");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobReady.Experience", b =>
                {
                    b.HasOne("JobReady.UserAccount", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JobReady.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobReady.UserAccount", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Industry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobReady.Faculty", b =>
                {
                    b.HasOne("JobReady.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("JobReady.FileLink", b =>
                {
                    b.HasOne("JobReady.UserAccount", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("JobReady.Follower", b =>
                {
                    b.HasOne("JobReady.UserAccount", "Following")
                        .WithMany("Followers")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobReady.UserAccount", "UserAccount")
                        .WithMany("Followings")
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Following");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("JobReady.JobApplication", b =>
                {
                    b.HasOne("JobReady.UserAccount", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobReady.JobPost", "JobPost")
                        .WithMany()
                        .HasForeignKey("JobPostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("JobPost");
                });

            modelBuilder.Entity("JobReady.JobPost", b =>
                {
                    b.HasOne("JobReady.UserAccount", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("JobReady.JobSkill", b =>
                {
                    b.HasOne("JobReady.JobPost", "JobPost")
                        .WithMany("Skills")
                        .HasForeignKey("JobPostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobReady.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JobPost");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("JobReady.Post", b =>
                {
                    b.HasOne("JobReady.UserAccount", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("JobReady.PostEngagement", b =>
                {
                    b.HasOne("JobReady.PostEngagement", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JobReady.UserAccount", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobReady.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("CreatedBy");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("JobReady.Recommendation", b =>
                {
                    b.HasOne("JobReady.UserAccount", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobReady.UserAccount", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instructor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("JobReady.UniversityMajor", b =>
                {
                    b.HasOne("JobReady.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobReady.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Major");

                    b.Navigation("University");
                });

            modelBuilder.Entity("JobReady.UserAccount", b =>
                {
                    b.HasOne("JobReady.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Industry");
                });

            modelBuilder.Entity("JobReady.UserSkill", b =>
                {
                    b.HasOne("JobReady.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobReady.UserAccount", "UserAccount")
                        .WithMany("Skills")
                        .HasForeignKey("UserAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JobReady.UserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JobReady.UserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobReady.UserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JobReady.UserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobReady.JobPost", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("JobReady.UserAccount", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("Followings");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
