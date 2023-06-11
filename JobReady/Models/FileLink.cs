using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JobReady;

public class FileLink
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; }

    [Display(Name = "Content Size")]
    [Required]
    public long ContentSize { get; set; }

    [Display(Name = "Content Hash")]
    [Required]
    public virtual System.Byte[] ContentHash { get; set; }

    [Display(Name = "Object Type")]
    public ObjectType? ObjectType { get; set; }
    public long? ObjectId { get; set; }

    [Display(Name = "Created On")]
    public DateTime CreatedOn { get; set; }
    [Required]
    public string CreatedById { get; set; }
    public UserAccount CreatedBy { get; set; }
}
