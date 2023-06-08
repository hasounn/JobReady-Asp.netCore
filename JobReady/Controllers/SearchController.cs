using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
