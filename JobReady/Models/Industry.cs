using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class Industry
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }
}
