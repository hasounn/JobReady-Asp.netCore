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
                         where i == null || i.ObjectType == ObjectType.Post
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
        public IEnumerable<JobPostDetails> GetJobPosts()
        {
            var Jobposts = (from x in context.JobPost
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
            return Jobposts;
        }
    }
}