using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace JobReady;

public class CompanyDetails
{
    public string Id { get; set; }

    [DisplayName("Full Name")]
    public string FullName { get; set; }

    public string Username { get; set; }

    [DisplayName("Email Address")]
    public string Email { get; set; }

    public string Password { get; set; }

    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; }

    public long? IndustryId { get; set; }
    public IndustryDetails Industry { get; set; }

    public string Headline { get; set; }

    public string About { get; set; }

    public string Location { get; set; }

    public bool IsVerified { get; set; }

    public bool IsEmailVerified { get; set; }

    [DisplayName("Founded On")]
    public DateTime UserDate { get; set; }

    public IEnumerable<SelectListItem> Industries { get; set; }
}
