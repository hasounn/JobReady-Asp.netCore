using System.ComponentModel;

namespace JobReady;

public class UserAccountDetails
{
    public string Id {get;set;}

    [DisplayName("Full Name")]
    public string FullName { get; set; }

    public string Username { get; set; }

    [DisplayName("Email Address")]
    public string Email { get; set; }

    public string Password { get; set; }

    public string Type { get; set; }

    private UserAccountType accountType;

    public UserAccountType AccountType
    {
        get
        {
            if (Type == "student") { return UserAccountType.Student; }
            if (Type == "instructor") { return UserAccountType.Instructor; }
            if (Type == "company") { return UserAccountType.Company; }
            if (Type == "admin") { return UserAccountType.Admin; }
            return UserAccountType.Student;
        }
        set
        {
            if (accountType != value)
            {
                accountType = value;
            }
        }
    }

    public Gender? Gender { get; set; }

    [DisplayName("Phone Number")]
    public long PhoneNumber { get; set; }

    public long? IndustryId { get; set; }
    public IndustryDetails Industry { get; set; }

    public string Headline { get; set; }

    public string About { get; set; }

    public string Location { get; set; }    

    public bool IsVerified { get; set; }

    public bool IsEmailVerified { get; set; }
    public bool IsOwned { get; set; }
    public bool HasFollowed { get; set; }
    public IEnumerable<UserAccountDetails> Followers { get; set; }
    [DisplayName("Date Of Birth")]
    public DateTime UserDate { get; set; }

    public IFormFile ProfileImage {get;set;}
    public IEnumerable<PostDetails> Posts { get; set; }
    public IEnumerable<JobPostDetails> JobPosts { get; set; }
    public string[] Skills { get; set; }
    public IEnumerable<EducationDetails> Educations { get; set; }
    public IEnumerable<ExperienceDetails> Experiences { get; set; }
    public void Validate()
    {
        if(AccountType == UserAccountType.Company && IndustryId == null)
        {
            throw new Exception("Industry is required");
        }
    }
}
