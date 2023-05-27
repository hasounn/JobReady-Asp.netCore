using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class Major
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

}
