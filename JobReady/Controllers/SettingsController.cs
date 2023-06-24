using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
