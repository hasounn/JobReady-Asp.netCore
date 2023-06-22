using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly JobReadyContext context;
        public SearchController(JobReadyContext context)
        {

            this.context = context;

        }
        public IActionResult Index(SearchDetails response)
        {
            return View(response);
        }

        [HttpPost]
        public IActionResult Search(SearchDetails request)
        {
            var searchText = request.SearchText;

            var users = (from x in context.UserAccount
                         where x.UserName.Contains(searchText)
                         select new UserAccountDetails()
                         {
                             Id = x.Id,
                             FullName = x.FullName,
                             Username = x.UserName,
                             Headline = x.Headline,
                         });
            var response = new SearchDetails()
            {
               SearchText = searchText,
                User = users,
            };
            return RedirectToAction("Index", "Search", new { response } );
        }
    }
}
