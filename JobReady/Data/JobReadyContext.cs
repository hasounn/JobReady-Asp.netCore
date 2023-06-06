using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JobReady;

public class JobReadyContext : IdentityDbContext<UserAccount>
{
    public JobReadyContext(DbContextOptions<JobReadyContext> options) : base(options)
    {
    }

    public DbSet<UserAccount> UserAccount { get; set; }
    public DbSet<Follower> Follower { get; set; }
    public DbSet<Industry> Industry{ get; set; }
    public DbSet<JobApplication> JobApplication { get; set; }
    public DbSet<JobPost> JobPost { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<Skill> Skill { get; set; }
    public DbSet<UserSkill> UserSkill { get; set; }
    public DbSet<PostEngagement> PostEngagement { get; set; }
    public DbSet<Recommendation> Recommendation { get; set; }
    public DbSet<JobSkill> JobSkill { get; set; }
    public DbSet<University> University { get; set; }
    public DbSet<Faculty> Faculty { get; set; }
    public DbSet<Major> Major { get; set; }
    public DbSet<UniversityMajor> UniversityMajor { get; set; }
    public DbSet<FileLink> FileLink { get; set; }
    public DbSet<Education> Education { get; set; }
    public DbSet<Experience> Experience { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Follower>()
        .HasOne(f => f.UserAccount)
        .WithMany(u => u.Followings)
        .HasForeignKey(f => f.UserAccountId)
        .HasPrincipalKey(u => u.Id)
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
