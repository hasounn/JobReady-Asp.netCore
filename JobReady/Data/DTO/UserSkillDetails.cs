using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class UserSkillDetails
{
    public long Id { get; set; }
    public string UserAccountId { get; set; }
    public UserAccountDetails UserAccount { get; set; }
    public long SkillId { get; set; }
    public Skill Skill { get; set; }
}
