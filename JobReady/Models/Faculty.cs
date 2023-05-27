using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class Faculty
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    public long UniversityId { get; set; }
    public University University { get; set; }

    [Required]
    public string BranchLocation { get; set; }

    [Required]
    public long BranchNumber { get; set; }

    public DateTime CreatedOn { get;set; }
}
