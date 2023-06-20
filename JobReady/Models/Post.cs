using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class Post
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(2000)]
    public string Content { get; set; }

    [Required]
    public string CreatedById { get; set; }
    public UserAccount CreatedBy { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }
}

