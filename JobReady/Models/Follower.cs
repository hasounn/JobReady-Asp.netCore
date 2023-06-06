using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobReady;

public class Follower
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string UserAccountId { get; set; }
    public UserAccount UserAccount { get; set; }

    [Required]
    [Display(Name = "Following")]
    public string FollowingId { get; set; }
    public UserAccount Following { get; set; }

    [Display(Name = "Followed On")]
    public DateTime FollowedOn { get; set; }
    [Display(Name = "Notification On")]
    public bool IsNotificationOn { get; set; }
}
