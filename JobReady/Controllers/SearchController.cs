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
        public IActionResult Index()
        {
            var userId = this.User.Claims.First().Value;
            var userType = (from x in context.UserAccount
                            where x.Id == userId
                            select x.AccountType).FirstOrDefault();
            ViewData["User"] = userType;
            return View();
        }

        [HttpPost]
        public IActionResult Index(SearchDetails request)
        {
            var searchText = request.SearchText;

            var users = (from x in context.UserAccount
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

            var postIds = (from y in context.Post
                           where y.Content.Contains(searchText)
                           select y.Id);

            var posts = postController.GetPosts(postIds, this.User.Claims.First().Value);

            var skills = (from s in context.Skill
                          where s.Name == searchText
                          select s.Id).ToArray();


            var jobPosts = (from j in context.JobPost
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

            var response = new SearchDetails()
            {
                SearchText = searchText,
                Users = users,
                Posts = posts,
                JobPosts = jobPosts
            };
            return View(response);
        }
    }
}
