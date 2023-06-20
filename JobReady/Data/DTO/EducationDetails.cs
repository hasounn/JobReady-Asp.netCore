using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class EducationDetails
{
    public long Id { get; set; }

    public string UserId { get; set; }
    public UserAccountDetails User { get; set; }

    public long? SchoolId { get; set; }
    public University School { get; set; }

    [Display(Name ="School Name")]
    public string SchoolName { get; set; }

    public DegreeType? Degree { get; set; }

    [Display(Name = "Other Degree")]
    public string OtherDegree { get; set; }

    [Display(Name = "Field Of Study")]
    public long? MajorId { get; set; }
    public Major Major { get; set; }

    public long? Grade { get; set; }

    public string Description { get; set; }

    [Display(Name = "Start Date")]
    public DateTime? StartDate { get; set; }

    [Display(Name = "End Date (or Expected)")]
    public DateTime? EndDate { get; set; }
}
