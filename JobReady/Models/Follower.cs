using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobReady;

public class Follower
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long UserAccountId { get; set; }
    public UserAccount UserAccount { get; set; }

    [Required]
    public long FollowingId { get; set; }
    public UserAccount Following { get; set; }
    public DateTime FollowedOn { get; set; }
    public bool IsNotificationOn { get; set; }
}
