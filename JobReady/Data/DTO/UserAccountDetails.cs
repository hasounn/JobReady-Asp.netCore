using System.ComponentModel;

namespace JobReady;

public class UserAccountDetails
{
    public long Id {get;set;}

    [DisplayName("Full Name")]
    public string FullName { get; set; }

    public string Username { get; set; }

    [DisplayName("Email Address")]
    public string Email { get; set; }

    public string Password { get; set; }

    public string Type { get; set; }

    public UserAccountType AccountType
    {
        get
        {
            if (Type == "student") {return UserAccountType.Student; }
            if (Type == "instructor") {return UserAccountType.Instructor; }
            else
            {
                throw new Exception("InvalidType");
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

    [DisplayName("Date Of Birth")]
    public DateTime UserDate { get; set; }

    public IFormFile ProfileImage {get;set;}

    public void Validate()
    {
        if(AccountType == UserAccountType.Company && IndustryId == null)
        {
            throw new Exception("Industry is required");
        }
    }
}
