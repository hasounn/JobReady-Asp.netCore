using System.ComponentModel;

namespace JobReady;
{
    public class ExperienceDetails
    {
        public long Id { get; set; }

        public string UserId { get; set; }
        public UserAccountDetails User { get; set; }

        public string Title { get; set; }

        [DisplayName("Employment Type")]
        public JobType EmploymentType { get; set; }

        public string CompanyId { get; set; }
        public UserAccountDetails Company { get; set; }
        public string CompanyName { get; set; }

        public long IndustryId { get; set; }
        public Industry Industry { get; set; }

        public string Description { get; set; }

        [DisplayName("Location Type")]
        public LocationType LocationType { get; set; }
        public string Location { get; set; }

        public bool IsCurrentlyWorking { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
