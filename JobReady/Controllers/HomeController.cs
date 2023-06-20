using JobReady.Data.DTO;
using JobReady.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobReady.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobReadyContext context;

        public HomeController(JobReadyContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var accountType = (from x in context.Users
                               where x.UserName == this.User.Identity.Name
                               select x.AccountType).FirstOrDefault();
            PostsDetails model = new PostsDetails() {Posts=GetPosts(),JobPosts=GetJobPosts(), AccountType = accountType };
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
            foreach(var post in posts)
            {
                post.LikesCount = GetTotalLikesCount(post.Id);
                post.HasLiked = HasLiked(post.Id, this.User.Claims.First().Value);
                post.Comments = GetPostComments(post.Id);
            }
            return posts.AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<JobPostDetails> GetJobPosts()
        {
            var jobPosts = (from x in context.JobPost
                         orderby x.CreatedOn descending
                         select new JobPostDetails()
                         {
                             Id = x.Id,
                             Title=x.Title,
                             JobType=x.JobType,
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
                            where x.Id == postId && x.EngagementType == EngagementType.Comment
                            select new PostEngagementDetails()
                            {
                                Id = x.Id,
                                Content = x.Content,
                                CreatedOn = x.CreatedOn,
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