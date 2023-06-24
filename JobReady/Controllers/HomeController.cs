using JobReady.Data.DTO;
using JobReady.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobReady.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly JobReadyContext context;

        public HomeController(JobReadyContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var user = (from x in context.Users
                               where x.UserName == this.User.Identity.Name
                               select new UserAccountDetails()
                               {
                                   Id = x.Id,
                                   Username = x.UserName,
                                   FullName = x.FullName,
                                   Type = x.AccountType == UserAccountType.Company ? "company" : 
                                          x.AccountType == UserAccountType.Student ? "student" :
                                          x.AccountType == UserAccountType.Instructor ? "instructor" :
                                          "admin",

                               }).FirstOrDefault();

            var model = new PostsDetails()
            {
                Posts = GetPosts(),
                JobPosts = GetJobPosts(),
                AccountType = user.AccountType,
            };
            ViewData["User"] = model.AccountType;
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IEnumerable<PostDetails> GetPosts()
        {
            var posts = (from x in context.Post
                         join y in context.FileLink on x.Id equals y.ObjectId into images
                         from i in images.DefaultIfEmpty()
                         where (i == null || i.ObjectType == ObjectType.Post)
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
                post.CreatedBy = GetUserAccount(post.CreatedById);
            }
            return posts.AsEnumerable();
        }

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

            return userDetails;
        }

        [HttpGet]
        public IEnumerable<JobPostDetails> GetJobPosts()
        {
            var jobPosts = (from x in context.JobPost
                            orderby x.CreatedOn descending
                            select new JobPostDetails()
                            {
                                Id = x.Id,
                                Title = x.Title,
                                JobType = x.JobType,
                                IsRemote = x.IsRemote,
                                CreatedBy = new UserAccountDetails()
                                {
                                    Id = x.CreatedById,
                                    Username = x.CreatedBy.UserName,
                                },
                                Description = x.Description,
                                CreatedById = x.CreatedById,
                                CreatedOn = x.CreatedOn,
                            }).AsEnumerable();
            return jobPosts;
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
                    where x.PostId == postId && x.CreatedById == userId && x.EngagementType == EngagementType.Like
                    select x).Any();
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
    }
}