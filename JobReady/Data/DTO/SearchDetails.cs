namespace JobReady;

public class SearchDetails
{
    public string SearchText { get; set; }
    public SearchType ResponseType { get; set; }
    public string Type { get; set; }
    public IEnumerable<UserAccountDetails> Users { get; set; }
    public IEnumerable<PostDetails> Posts { get; set; }
    public IEnumerable<JobPostDetails> JobPosts { get; set; }
}
