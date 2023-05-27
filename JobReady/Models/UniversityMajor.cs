using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class UniversityMajor
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long UniversityId { get; set; }
    public University University { get; set; }

    [Required]
    public long MajorId { get; set; }
    public Major Major { get; set; }
}
