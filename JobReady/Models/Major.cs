using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class Major
{
    [Key]
    public long Id;

    [Required]
    public string Name;

}
