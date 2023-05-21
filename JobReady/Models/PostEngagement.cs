using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobReady;

public class PostEngagement
{

    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(2000)]
    public string Content { get; set; }

    [Required]
    public long PostId { get; set; }
    public Post Post { get; set; }

    [Required]
    public EngagementType EngagementType { get; set; }
    public long CommentId { get; set; }
    public PostEngagement Comment { get; set; }

    [Required]
    public long CreatedById { get; set; }
    public UserAccount CreatedBy { get; set; }
    [Required]
    public DateTime CreatedOn { get; set; }
}
