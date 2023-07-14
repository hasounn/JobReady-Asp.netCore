using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly JobReadyContext context;
        private PostController postController;
        public SearchController(JobReadyContext context)
        {
            this.context = context;
            postController = new PostController(context);
        }
        [HttpGet]
        public IActionResult Index(SearchDetails details)
        {
            var userId = this.User.Claims.First().Value;
            var userType = (from x in context.UserAccount
                            where x.Id == userId
                            select x.AccountType).FirstOrDefault();
            ViewData["User"] = userType;
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult Search(SearchDetails request)
        {
            var searchText = request.SearchText;

            var postIds = (from y in context.Post
                           where y.Content.Contains(searchText)
                           select y.Id);

            var posts = postController.GetPosts(postIds, this.User.Claims.First().Value);

            var response = new SearchDetails()
            {
                SearchText = searchText,
                Users = (request.Type == "Users" || string.IsNullOrEmpty(request.Type)) ? GetUsers(searchText) : null,
                Posts = (request.Type == "Posts" || string.IsNullOrEmpty(request.Type)) ? posts : null,
                JobPosts = (request.Type == "JobPosts" || string.IsNullOrEmpty(request.Type)) ? GetJobPosts(searchText) : null
            };
            return View(response);
        }

        [HttpGet]
        public IActionResult SearchPosts(SearchDetails request)
        {
            request.ResponseType = SearchType.Posts;
            return Search(request);
        }

        IEnumerable<UserAccountDetails> GetUsers(string searchText)
        {
            return (from x in context.UserAccount
             where x.UserName.Contains(searchText)
             || x.FullName.Contains(searchText)
             || x.Industry.Name.Contains(searchText)
             select new UserAccountDetails()
             {
                 Id = x.Id,
                 FullName = x.FullName,
                 Username = x.UserName,
                 Headline = x.Headline,
             }).ToArray();
        }

        IEnumerable<JobPostDetails> GetJobPosts(string searchText)
        {
            var skills = (from s in context.Skill
                          where s.Name == searchText
                          select s.Id).ToArray();


            return (from j in context.JobPost
                            where (j.Title.Contains(searchText) ||
                            j.Skills.Any(t => skills.Contains(t.Id))
                            || j.CreatedBy.Industry.Name.Contains(searchText))
                            && j.IsActive
                            select new JobPostDetails()
                            {
                                Id = j.Id,
                                Title = j.Title,
                                CreatedById = j.CreatedById,
                                IsRemote = j.IsRemote,
                                CreatedBy = new UserAccountDetails()
                                {
                                    Username = j.CreatedBy.UserName,
                                    Id = j.CreatedBy.Id
                                },
                                PostedOn = $"{j.CreatedOn.Date} - {j.CreatedOn.ToShortTimeString()}",
                            }).ToArray();
        }
        [HttpPost]
        public IActionResult ApplyFilter(SearchDetails request)
        {
            return RedirectToAction("Index", "Search", new { request }); ;
        }
    }
}
