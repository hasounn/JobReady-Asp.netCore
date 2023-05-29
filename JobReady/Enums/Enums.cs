using System.ComponentModel.DataAnnotations;

namespace JobReady;

public enum UserAccountType
{
    Admin = 1,
    Student,
    Instructor,
    Company
}

public enum Gender
{
    Female,
    Male,
    [Display(Name = "Prefer Not To Say")]
    PreferNotToSay
}

public enum JobType
{
    Internship,
    [Display(Name = "Entry Level")]
    EntryLevel,
    [Display(Name = "Part Time")]
    PartTime,
    Freelance,
    [Display(Name = "Research Assistant")]
    ResearchAssistant
}

public enum EngagementType
{
    Comment,
    Like,
    Report,
    Share
}

public enum RecommendationStatus
{
    Pending,
    Accepted,
    Rejected
}

public enum ObjectType
{
    UserAccount,
    Post,
    JobPost
}