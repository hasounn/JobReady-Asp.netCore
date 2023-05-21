﻿using System.ComponentModel.DataAnnotations;

namespace JobReady;

public class UserAccount
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Display(Name = "Email address")]
    [Required(ErrorMessage = "The email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Required]
    [StringLength(50)]
    public string Password { get; set; }

    [Required]
    public UserAccountType AccountType { get; set; }

    public long IndustryId { get; set; }
    public Industry Industry { get; set; }

    [StringLength(200)]
    public string Headline { get; set; }

    [StringLength(2000)]
    public string About { get; set; }

    [StringLength(100)]
    public string Location { get; set; }
    public ICollection<UserSkill> Skills { get; set; }
    public ICollection<Follower> Followings { get; set; }
    public ICollection<Follower> Followers { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}
