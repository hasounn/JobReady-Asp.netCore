using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
