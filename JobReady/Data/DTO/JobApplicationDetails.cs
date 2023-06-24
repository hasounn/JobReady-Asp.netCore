using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class JobApplicationDetails
{
    public long Id { get; set; }
    public string ApplicantId { get; set; }
    public UserAccountDetails Applicant { get; set; }
    public long JobPostId { get; set; }
    public JobPostDetails JobPost { get; set; }
    public string LetterOfMotivation { get; set; }
    public DateTime AppliedOn { get; set; }
    public bool IsCompany { get; set; }
    public IEnumerable<SkillDetails> Skills { get; set;}
}
