using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobReady;

public class UserSkill
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string UserAccountId { get; set; }
    public UserAccount UserAccount { get; set; }
    [Required]
    public long SkillId { get; set; }
    public Skill Skill { get; set; }
}
