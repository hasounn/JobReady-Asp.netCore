using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class Experience
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long UserId { get; set; }
    public UserAccount User { get; set; }

    [Required]
    public string Title { get; set; }

    [DisplayName("Employment Type")]
    public JobType EmploymentType { get; set; }

    public long? CompanyId { get; set; }
    public UserAccount Company { get; set; }
    public string CompanyName { get; set; }

    [Required]
    public long IndustryId { get; set; }
    public Industry Industry { get; set; }

    public string Description { get; set; }

    [DisplayName("Location Type")]
    public LocationType LocationType { get; set; }
    public string Location { get; set; }

    public bool IsCurrentlyWorking { get; set; }

    [Required]
    [DisplayName("Start Date")]
    public DateTime StartDate { get; set; }

    [DisplayName("End Date")]
    public DateTime? EndDate { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }
    [Required]
    public DateTime ModifiedOn { get; set; }    
}
