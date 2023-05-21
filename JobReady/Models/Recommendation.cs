using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobReady;

public class Recommendation
{
    [Key]
    public long Id { get; set; }
    [Required]
    public long StudentId { get; set; }
    public UserAccount Student {  get; set; }
    [Required]
    public long InstructorId { get; set; }
    public UserAccount Instructor { get; set; }
    [Required]
    public RecommendationStatus Status { get; set; }
    [Required]
    [StringLength(500)]
    [InverseProperty("StudentRequest")]
    public string StudentRequest { get; set; }
    [StringLength(2000)]
    [InverseProperty("InstructorReply")]
    public string InstructorReply { get; set; }
}
