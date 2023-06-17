using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class JobApplicationDetails
{
    public long Id { get; set; }
    public string ApplicantId { get; set; }
    public UserAccountDetails Applicant { get; set; }
    public long JobPostId { get; set; }
    public JobPost JobPost { get; set; }
    public string LetterOfMotivation { get; set; }
    public DateTime AppliedOn { get; set; }
}
