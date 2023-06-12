using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JobPost()
        {
            return View();
        }
    }
}
