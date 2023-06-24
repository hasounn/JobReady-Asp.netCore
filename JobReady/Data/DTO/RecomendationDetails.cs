namespace JobReady;
public class RecommendationDetails
{
    public long Id { get; set; }
    public string StudentId { get; set; }
    public UserAccountDetails Student { get; set; }
    public string InstructorId { get; set; }
    public UserAccountDetails Instructor { get; set; }
    public RecommendationStatus Status { get; set; }
    public string StudentRequest { get; set; }
    public string InstructorReply { get; set; }
    public DateTime? RequestDate { get; set; }
    public DateTime? ResponseDate { get; set; }
    public bool IsStudent { get; set; }
    public RecommendationReply Reply { get; set; }
}
