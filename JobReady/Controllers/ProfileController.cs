using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
