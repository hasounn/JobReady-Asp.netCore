using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobReady.Data.DTO
{
    public class SignUpUserRegistry
    {
        public string Type { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [DisplayName("Username")]
        public string Username { get; set; }
        [DisplayName("Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime Dob { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("Gender")]
        public Gender Gender { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        [DisplayName("Headline")]
        public string Headline { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}