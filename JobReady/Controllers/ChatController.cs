using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
