using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobReady;

public class JobSkill
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long JobPostId { get; set; }
    public JobPost JobPost { get; set; }
    [Required]
    public long SkillId { get; set; }
    public Skill Skill { get; set; }
}
