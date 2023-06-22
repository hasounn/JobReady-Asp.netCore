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
    [Display(Name = "Bachelor of Arts")]
    BachelorOfArts,

    [Display(Name = "Bachelor of Science")]
    BachelorOfScience,

    [Display(Name = "Bachelor of Business Administration")]
    BachelorOfBusinessAdministration,

    [Display(Name = "Bachelor of Engineering")]
    BachelorOfEngineering,

    [Display(Name = "Bachelor of Education")]
    BachelorOfEducation,

    [Display(Name = "Bachelor of Fine Arts")]
    BachelorOfFineArts,

    [Display(Name = "Master of Arts")]
    MasterOfArts,

    [Display(Name = "Master of Science")]
    MasterOfScience,

    [Display(Name = "Master of Business Administration")]
    MasterOfBusinessAdministration,

    [Display(Name = "Master of Education")]
    MasterOfEducation,

    [Display(Name = "Master of Engineering")]
    MasterOfEngineering,

    [Display(Name = "Master of Fine Arts")]
    MasterOfFineArts,

    [Display(Name = "Doctor of Philosophy")]
    DoctorOfPhilosophy,

    [Display(Name = "Doctor of Medicine")]
    DoctorOfMedicine,

    [Display(Name = "Doctor of Education")]
    DoctorOfEducation,

    [Display(Name = "Juris Doctor")]
    JurisDoctor,

    [Display(Name = "Doctor of Dental Surgery")]
    DoctorOfDentalSurgery,

    [Display(Name = "Doctor of Dental Medicine")]
    DoctorOfDentalMedicine,

    [Display(Name = "Associate of Arts")]
    AssociateOfArts,

    [Display(Name = "Associate of Science")]
    AssociateOfScience
}

public enum SearchType
{
    Users,
    Posts,
    [Display(Name="Job Opportunities")]
    Jobs
}