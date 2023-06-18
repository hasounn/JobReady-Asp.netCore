namespace JobReady.Data.DTO
{
    public class PostsDetails
    {
        public IEnumerable<PostDetails> Posts { get; set;}
        public IEnumerable<JobPostDetails> JobPosts { get; set;}
    }
}
