using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
