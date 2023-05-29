using JobReady.Models;
using Microsoft.EntityFrameworkCore;

namespace JobReady;

public class JobReadyContext : DbContext
{
    public JobReadyContext(DbContextOptions<JobReadyContext> options) : base(options)
    {
    }

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<Follower> Followers { get; set; }
    public DbSet<Industry> Industries { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
    public DbSet<JobPost> JobPosts { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<PostEngagement> PostEngagements { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }
    public DbSet<JobSkill> JobSkills { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Major> Majors { get; set; }
    public DbSet<UniversityMajor> UniversityMajors { get; set; }
    public DbSet<FileLink> FileLinks { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Follower>()
        .HasOne(f => f.UserAccount)
        .WithMany(u => u.Followings)
        .HasForeignKey(f => f.UserAccountId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Follower>()
            .HasOne(f => f.Following)
            .WithMany(u => u.Followers)
            .HasForeignKey(f => f.FollowingId)
            .OnDelete(DeleteBehavior.Restrict);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        base.OnModelCreating(modelBuilder);
    }
}
