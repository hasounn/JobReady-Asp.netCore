using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobReady.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly JobReadyContext context;
        public ProfileController(JobReadyContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string userId = null)
        {
            if (IsCompany(userId))
            {
                return RedirectToAction("Company", "Profile", new {userId});
            }
            else
            {
                var userDetails = GetUserAccount(userId);
                return View(userDetails);
            }
        }

        public IActionResult Company(string userId = null)
        {
            var userDetails = GetUserAccount(userId);
            userDetails.JobPosts = Enumerable.Empty<JobPostDetails>();
            if (!IsCompany(userId))
            {
                return RedirectToAction("Index","Company", new { userId});
            }
            else
            {
                return View(userDetails);
            }
        }


        public IActionResult Edit(string userId = null)
        {
            var userDetails = GetUserAccount(userId);
            return View(userDetails);
        }

        #region Check Account Type
        private bool IsCompany(string userId)
        {
            userId ??= this.User.Claims.First().Value;
            var type = (from x in context.UserAccount
                        where x.Id == userId
                        select x.AccountType).FirstOrDefault();
            return type == UserAccountType.Company;
        }
        #endregion

        #region Get User Account
        private UserAccountDetails GetUserAccount(string userId)
        {
            userId ??= this.User.Claims.First().Value;
            var userDetails = (from x in context.UserAccount
                               where x.Id == userId
                               select new UserAccountDetails()
                               {
                                   Id = x.Id,
                                   Username = x.UserName,
                                   Headline = x.Headline,
                                   About = x.About,
                                   Type = x.AccountType == UserAccountType.Student ? "student" :
                                          x.AccountType == UserAccountType.Instructor ? "instructor" :
                                          x.AccountType == UserAccountType.Company ? "company" : "admin",
                                   FullName = x.FullName,
                                   UserDate = x.UserDate,
                                   IndustryId = x.IndustryId,
                                   Email = x.Email,
                                   Location = x.Location,
                                   IsVerified = x.IsVerified,
                                   IsOwned = x.Id == this.User.Claims.First().Value,
                               }).FirstOrDefault();
            userDetails.OriginalType = (from x in context.UserAccount
                                        where x.Id == this.User.Claims.First().Value
                                        select x.AccountType).FirstOrDefault();
            userDetails.Posts = GetUserPosts(userId ?? this.User.Claims.First().Value);
            userDetails.Skills = GetUserSkills(userId ?? this.User.Claims.First().Value);
            userDetails.UserSkills = GetAllUserSkills(userId ?? this.User.Claims.First().Value);
            userDetails.AllSkills = GetAllSkills();
            userDetails.Skill = new SkillDetails();
            userDetails.Industries = (from x in context.Industry select new SelectListItem() { Value = x.Id.ToString() , Text = x.Name}).AsQueryable();
            userDetails.Universities = (from x in context.University select new SelectListItem() { Value = x.Id.ToString() , Text = x.Name}).AsQueryable();
            userDetails.HasFollowed = userId != null ? HasFollowed(userId) : false;
            userDetails.Followers = GetFollowers(userId);
            userDetails.Experiences = GetExperiences(userId);
            userDetails.Experience = new ExperienceDetails();
            userDetails.Educations = GetEducations(userId);
            userDetails.Education = new EducationDetails();
            return userDetails;
        }

        public async Task<IActionResult> GetProfilePicture(string userId)
        {
            var photoId = (from x in context.FileLink
                           where x.ObjectType == ObjectType.UserAccount
                           && x.CreatedById == userId
                           select x.Id).FirstOrDefault();

            var photo = await context.FileLink.FindAsync(photoId);
            if (photo != null)
            {
                return File(photo.ContentHash, "image/*");
            }
            return File("/assets/images/image-placeholder.png", "image/png");
        }
        #endregion

        #region Update About
        public IActionResult UpdateAbout(UserAccountDetails source)
        {
            var target = (from x in context.UserAccount
                        where x.Id == this.User.Claims.First().Value
                        select x).FirstOrDefault();
            target.About = source.About;
            context.SaveChanges();
            return RedirectToAction("Index", "Profile", new { userId = target.Id });
        }
        #endregion

        #region Get User Skills / Likes
        [HttpGet]
        public string[] GetUserSkills([FromBody] string userId)
        {
            var skills = (from x in context.UserSkill
                          join y in context.Skill on x.SkillId equals y.Id
                          where x.UserAccountId == userId
                          select y.Name).ToArray();
            return skills;
        }
        public IEnumerable<SkillDetails> GetAllUserSkills(string userId)
        {
            var skills = (from x in context.UserSkill
                          join y in context.Skill on x.SkillId equals y.Id
                          where x.UserAccountId == userId
                          select new SkillDetails()
                          {
                              Id = x.Skill.Id,
                              Name = x.Skill.Name
                          }).ToArray();
            return skills;
        }
        public IEnumerable<SkillDetails> GetAllSkills()
        {
            var skills = (from x in context.Skill
                          select new SkillDetails()
                          {
                              Id = x.Id,
                              Name = x.Name
                          }).ToArray();
            return skills;
        }
        public long GetTotalLikesCount(long postId)
        {
            var likesCount = (from x in context.PostEngagement
                              where x.PostId == postId && x.EngagementType == EngagementType.Like
                              select x).Count();
            return likesCount;
        }
        public bool HasLiked(long postId, string userId)
        {
            return (from x in context.PostEngagement
                    where x.PostId == postId && x.CreatedById == userId
                    && x.EngagementType == EngagementType.Like
                    select x).Any();
        }
        #endregion

        #region Follow/Unfollow
        [HttpGet]
        public IActionResult Follow(string userId)
        {
            if (userId == null) return BadRequest();
            if (!HasFollowed(userId))
            {
                var newFollower = new Follower()
                {
                    UserAccountId = this.User.Claims.First().Value,
                    FollowingId = userId,
                    FollowedOn = DateTime.Now,
                };
                context.Follower.Add(newFollower);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Profile", new { userId });
        }
        [HttpGet]
        public IActionResult Unfollow(string userId)
        {
            if (userId == null) return BadRequest();

            var loggedInUserId = this.User.Claims.First().Value;
            var existingFollower = (from x in context.Follower
                                    where x.FollowingId == userId && x.UserAccountId== loggedInUserId
                                    select x).FirstOrDefault();

            if (existingFollower != null)
            {
                context.Follower.Remove(existingFollower);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Profile", new { userId });
        }

        public bool HasFollowed(string userId)
        {
            var followerId = this.User.Claims.First().Value;
            return (from x in context.Follower
                    where x.UserAccountId == followerId && x.FollowingId == userId
                    select x).Any();
        }

        [HttpGet]
        public IQueryable<UserAccountDetails> GetFollowers(string userId)
        {
            var followers = (from x in context.Follower
                             where x.FollowingId == userId
                             select new UserAccountDetails()
                             {
                                 Id = x.UserAccountId,
                                 Username = x.UserAccount.UserName,
                             });
            return followers;
        }
        #endregion

        #region Get Post / Comments
        public IEnumerable<PostDetails> GetUserPosts(string userId)
        {
            var posts = (from x in context.Post
                         join y in context.FileLink on x.Id equals y.ObjectId into images
                         from i in images.DefaultIfEmpty()
                         where (i == null || i.ObjectType == ObjectType.Post) && x.CreatedById == userId
                         orderby x.CreatedOn descending
                         select new PostDetails()
                         {
                             Id = x.Id,
                             CreatedBy = new UserAccountDetails()
                             {
                                 Id = x.CreatedById,
                                 FullName = x.CreatedBy.FullName,
                                 Headline = x.CreatedBy.Headline,
                                 Username = x.CreatedBy.UserName,
                             },
                             Content = x.Content,
                             ImageId = i.Id,
                             CreatedById = x.CreatedById,
                             CreatedOn = x.CreatedOn,
                         }).ToList();
            foreach (var post in posts)
            {
                post.LikesCount = GetTotalLikesCount(post.Id);
                post.HasLiked = HasLiked(post.Id, this.User.Claims.First().Value);
                post.Comments = GetPostComments(post.Id);
            }

            return posts;
        }

        public IEnumerable<PostEngagementDetails> GetPostComments(long postId)
        {
            var comments = (from x in context.PostEngagement
                            where x.PostId == postId && x.EngagementType == EngagementType.Comment
                            select new PostEngagementDetails()
                            {
                                Id = x.Id,
                                Content = x.Content,
                                CreatedOn = x.CreatedOn,
                                PostedOn = $"{x.CreatedOn.Date} - {x.CreatedOn.ToShortTimeString()}",
                                CreatedById = x.CreatedById,
                                CreatedBy = new UserAccountDetails()
                                {
                                    Id = x.CreatedBy.Id,
                                    FullName = x.CreatedBy.FullName,
                                    Username = x.CreatedBy.UserName,
                                }
                            }).AsEnumerable();
            return comments;
        }
        #endregion

        #region Add Experience
        [HttpPost]
        public IActionResult AddExperience(UserAccountDetails details)
        {
            if (ModelState.IsValid)
            {
                var experience = new Experience()
                {
                    Title = details.Experience.Title,
                    CompanyName = details.Experience.CompanyName,
                    EmploymentType = details.Experience.EmploymentType,
                    IsCurrentlyWorking = details.Experience.IsCurrentlyWorking,
                    UserId = this.User.Claims.First().Value,
                    IndustryId = details.Experience.IndustryId,
                    Description = details.Experience.Description,
                    EndDate = details.Experience.EndDate,
                    StartDate = details.Experience.StartDate,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                };
                context.Experience.Add(experience);
                context.SaveChanges();
            }
            return RedirectToAction("Edit", "Profile");
        }
        #endregion

        #region Update Experience
        [HttpPost]
        public IActionResult UpdateExperience(UserAccountDetails details)
        {
            if (ModelState.IsValid)
            {
                var target = (from x in context.Experience
                              where x.Id == details.Experience.Id
                              select x).FirstOrDefault();

                target.Title = details.Experience.Title;
                target.CompanyName = details.Experience.CompanyName;
                target.EmploymentType = details.Experience.EmploymentType;
                target.IsCurrentlyWorking = details.Experience.IsCurrentlyWorking;
                target.Description = details.Experience.Description;
                target.EndDate = details.Experience.EndDate;
                target.StartDate = details.Experience.StartDate;
                target.ModifiedOn = DateTime.Now;
                context.SaveChanges();
            }
            return RedirectToAction("Edit", "Profile");
        }
        #endregion

        #region Get Experiences
        public IEnumerable<ExperienceDetails> GetExperiences(string userId = null)
        {
            userId ??= this.User.Claims.First().Value;
            var experiences = (from x in context.Experience
                               where x.UserId == userId
                               orderby x.StartDate descending
                               select new ExperienceDetails()
                               {
                                   Id = x.Id,
                                   Title = x.Title,
                                   Description = x.Description,
                                   EmploymentType = x.EmploymentType,
                                   IndustryId = x.IndustryId,
                                   StartDate = x.StartDate,
                                   EndDate = x.EndDate,
                                   CompanyName = x.CompanyName,
                                   IsCurrentlyWorking = x.IsCurrentlyWorking,
                               }
                               ).ToArray();
            return experiences;
        }
        #endregion

        #region Add Education
        [HttpPost]
        public IActionResult AddEducation(UserAccountDetails details)
        {
            if (ModelState.IsValid)
            {
                var education = new Education()
                { 
                    SchoolId = details.Education.SchoolId,
                    FieldOfStudy = details.Education.FieldOfStudy,
                    Degree = details.Education.Degree,
                    StartDate = details.Education.StartDate,
                    EndDate = details.Education.EndDate,
                    Description = details.Education.Description,
                    UserId = this.User.Claims.First().Value,
                };
                context.Education.Add(education);
                context.SaveChanges();
            }
            return RedirectToAction("Edit", "Profile");
        }
        #endregion

        #region Update Education
        [HttpPost]
        public IActionResult UpdateEducation(UserAccountDetails details)
        {
            if (ModelState.IsValid)
            {
                var target = (from x in context.Education
                              where x.Id == details.Education.Id
                              select x).FirstOrDefault();

                target.SchoolId = details.Education.SchoolId; 
                target.FieldOfStudy = details.Education.FieldOfStudy;
                target.Degree = details.Education.Degree;
                target.Description = details.Education.Description;
                target.StartDate = details.Education.StartDate;
                target.EndDate = details.Education.EndDate;
                context.SaveChanges();
            }
            return RedirectToAction("Edit", "Profile");
        }
        #endregion

        #region Get Educations
        public IEnumerable<EducationDetails> GetEducations(string userId = null)
        {
            userId ??= this.User.Claims.First().Value;
            var educations = (from x in context.Education
                               where x.UserId == userId
                               orderby x.StartDate descending
                               select new EducationDetails()
                               {
                                   Id = x.Id,
                                   SchoolId = x.SchoolId,
                                   School = new UniversityDetails() { Name = x.School.Name},
                                   FieldOfStudy = x.FieldOfStudy,
                                   Degree = x.Degree,
                                   Description = x.Description,
                                   StartDate = x.StartDate,
                                   EndDate = x.EndDate,
                               }
                               ).ToArray();
            return educations;
        }
        #endregion

        #region  Add Skill in Edit
        public IActionResult AddSkillInEdit(UserAccountDetails details)
        {
            var skill = new UserSkill()
            {
                SkillId = details.Skill.Id,
                UserAccountId = this.User.Claims.First().Value,
            };
            context.UserSkill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("Edit","Profile");
        }
        #endregion

        #region  Delete Skill in Edit
        public IActionResult DeleteSkill(UserAccountDetails details)
        {
            var skill = (from x in context.UserSkill
                         where x.SkillId == details.Skill.Id &&
                         x.UserAccountId == this.User.Claims.First().Value
                         select x).FirstOrDefault();

            context.UserSkill.Remove(skill);
            context.SaveChanges();
            return RedirectToAction("Edit", "Profile");
        }
        #endregion

    }
}