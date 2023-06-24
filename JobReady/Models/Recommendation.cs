using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobReady;

public class Recommendation
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string StudentId { get; set; }
    public UserAccount Student {  get; set; }

    [Required]
    public string InstructorId { get; set; }
    public UserAccount Instructor { get; set; }

    [Required]
    public RecommendationStatus Status { get; set; }

    [Required]
    [StringLength(500)]
    [InverseProperty("StudentRequest")]
    public string StudentRequest { get; set; }

    [Required]
    [StringLength(2000)]
    [InverseProperty("InstructorReply")]
    public string InstructorReply { get; set; }

    [Display(Name="Request Date")]
    public DateTime? RequestDate { get; set; }

    [Display(Name="Response Date")]
    public DateTime? ResponseDate { get; set; }
}
