namespace JobReady
{
    public class NotificationEngagementDetails
    {
        public UserAccountDetails CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string PostedOn { get; set; }
        public EngagementType EngagementType { get; set; }
        public string Content { get; set; }
    }
}
