using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class UserAccount : IdentityUser
{
    [Required]
    [StringLength(50)]
    public string FullName { get; set; }

    [Required]
    public UserAccountType AccountType { get; set; }

    public Gender? Gender { get; set; }

    public long? IndustryId { get; set; }
    public Industry Industry { get; set; }

    [StringLength(200)]
    public string Headline { get; set; }

    [StringLength(2000)]
    public string About { get; set; }

    [StringLength(100)]
    public string Location { get; set; }

    public bool IsVerified { get; set; }

    public bool IsEmailVerified { get; set; }

    public ICollection<UserSkill> Skills { get; set; }

    public ICollection<Follower> Followings { get; set; }

    public ICollection<Follower> Followers { get; set; }

    [Required]
    public DateTime UserDate { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }
}
