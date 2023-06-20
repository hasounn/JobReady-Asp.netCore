using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class JobPost
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; }

    [Required]
    [Display(Name="Type")]
    public JobType JobType { get; set; }

    [Required]
    [StringLength(2000)]
    public string Description { get; set; }
    [Display(Name = "Active")]
    public bool IsActive { get; set; }

    [Display(Name ="Remote")]
    public bool? IsRemote { get; set; }

    [Required]
    public string CreatedById { get; set; }
    public UserAccount CreatedBy { get; set; }
    [Required]
    public DateTime CreatedOn { get; set; }
    public ICollection<JobSkill> Skills { get; set; }

}
