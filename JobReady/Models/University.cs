using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class University
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public string HeadQuarterLocation { get; set; }
    public long BranchesCount { get; set; }

}
