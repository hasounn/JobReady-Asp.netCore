namespace JobReady;

public class SearchDetails
{
    public string SearchText { get; set; }
    public SearchType ResponseType { get; set; }
    public IEnumerable<UserAccountDetails> User { get; set; }
    public PostDetails Post { get; set; }
    public JobPostDetails JobPost { get; set; }
}
