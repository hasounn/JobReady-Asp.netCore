using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobReady;
public class JobApplication
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string ApplicantId { get; set; }
    public UserAccount Applicant { get; set; }

    [Required]
    public long JobPostId { get; set; }
    public JobPost JobPost { get; set; }

    [Required]
    [StringLength(500)]
    public string LetterOfMotivation { get; set; }
    public DateTime AppliedOn { get; set; }
    
}
