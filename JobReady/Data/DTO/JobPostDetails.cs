namespace JobReady;

public class JobPostDetails
{
    public long Id { get; set; }
    public string Title { get; set; }
    public JobType JobType { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public bool? IsRemote { get; set; }
    public IEnumerable<SkillDetails> Skills { get; set; }
    public string CreatedById { get; set; }
    public UserAccountDetails CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string PostedOn { get; set; }
    public bool HasApplied { get; set; }
    public string Validate()
    {
        if (string.IsNullOrEmpty(Title))
        {
            return "Title is required";
        }
        if(string.IsNullOrEmpty(Description))
        {
            return "Job Description is required";
        }
        return null;
    }
    public string LetterOfMotivation { get; set; }
}
