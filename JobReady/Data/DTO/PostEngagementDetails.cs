using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class PostEngagementDetails
{
    public long Id { get; set; }
    public string Content { get; set; }
    public long PostId { get; set; }
    public Post Post { get; set; }
    public EngagementType EngagementType { get; set; }
    public long CommentId { get; set; }
    public PostEngagementDetails Comment { get; set; }
    public string CreatedById { get; set; }
    public UserAccountDetails CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string PostedOn { get; set; }
}
