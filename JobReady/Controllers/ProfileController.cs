using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class ProfileController : Controller
    {
        private readonly JobReadyContext context;
        private UserAccountDetails userDetails;
        public ProfileController(JobReadyContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index(string userId = null)
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

            userDetails.Posts = GetUserPosts(userId?? this.User.Claims.First().Value);
            userDetails.Skills = GetUserSkills(userId?? this.User.Claims.First().Value);
            this.userDetails = userDetails;
            if (userDetails.AccountType == UserAccountType.Company)
            {
                return ProfileComp();
            }
            return Index();
        }

        private IActionResult Index()
        {
            return View(userDetails);
        }

        private IActionResult ProfileComp()
        {
            return View(userDetails);
        }

        public async Task<IActionResult> GetProfilePicture(string userId)
        {
            var photoId = (from x in context.FileLink
                           where x.ObjectType == ObjectType.UserAccount
                           && x.CreatedById == userId
                           select x.Id).FirstOrDefault();

            var photo = await context.FileLink.FindAsync(photoId);
            if(photo != null)
            {
                return File(photo.ContentHash, "image/*");
            }
            return File("/assets/images/image-placeholder.png", "image/png");
        }

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
                                 Headline = x.CreatedBy.Headline,
                                 Username = x.CreatedBy.UserName,
                             },
                             Content = x.Content,
                             ImageId = i.Id,
                             CreatedById = x.CreatedById,
                             CreatedOn = x.CreatedOn,
                         }).AsEnumerable();
            return posts;
        }

        [HttpGet]
        public string[] GetUserSkills([FromBody] string userId)
        {
            var skills = (from x in context.UserSkill
                          join y in context.Skill on x.SkillId equals y.Id
                          where x.UserAccountId == userId
                          select y.Name).ToArray();
            return skills;
        }

        [HttpGet]
        public IActionResult Follow(string userId)
        {
            if(userId == null) return BadRequest();
            var newFollower = new Follower()
            {
                UserAccountId = this.User.Claims.First().Value,
                FollowingId = userId,
                FollowedOn = DateTime.Now,
            };
            context.Follower.Add(newFollower);
            context.SaveChanges();
            return RedirectToAction("Profile", "Index", userId);
        }
        
        public bool HasFollowed(string userId)
        {
            var followerId = this.User.Claims.First().Value;
            return (from x in context.Follower
                    where x.UserAccountId == followerId && x.FollowingId == userId
                    select x).Any();
        }
    }
}
