namespace JobReady.Data.DTO
{
    public class JobPostDetails
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public JobType JobType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemote { get; set; }
        public IEnumerable<SkillDetails> Skills { get; set; }
        public string CreatedById { get; set; }
        public UserAccountDetails CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
