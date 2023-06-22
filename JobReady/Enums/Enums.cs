using System.ComponentModel;
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
    ResearchAssistant,
    Junior,
    Trainee,
    Apprentice,
    Assistant
}

public enum LocationType
{
    [Display(Name = "On-Site")]
    Onsite,
    Hybrid,
    Remote
}
public enum EngagementType
{
    Comment,
    Like,
    Report,
    Share,
    Follow,
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

public enum DegreeType
{
    BachelorOfArts,
    BachelorOfScience,
    BachelorOfBusinessAdministration,
    BachelorOfEngineering,
    BachelorOfEducation,
    BachelorOfFineArts,
    MasterOfArts,
    MasterOfScience,
    MasterOfBusinessAdministration,
    MasterOfEducation,
    MasterOfEngineering,
    MasterOfFineArts,
    DoctorOfPhilosophy,
    DoctorOfMedicine,
    DoctorOfEducation,
    JurisDoctor,
    DoctorOfDentalSurgery,
    DoctorOfDentalMedicine,
    AssociateOfArts,
    AssociateOfScience,
    Other
}

public enum SearchType
{
    Users,
    Posts,
    [Display(Name="Job Opportunities")]
    Jobs
}