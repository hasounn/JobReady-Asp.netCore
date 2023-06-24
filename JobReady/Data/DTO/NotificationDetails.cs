namespace JobReady;

public class NotificationDetails
{
    public IEnumerable<NotificationEngagementDetails> Engagements { get; set; }
    public IEnumerable<JobApplicationDetails> Applications { get; set; }
    public IEnumerable<RecommendationDetails> Recommendations { get; set;}

    public string Partial { get; set; }

}
