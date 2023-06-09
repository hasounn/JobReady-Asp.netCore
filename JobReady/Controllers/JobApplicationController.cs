using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class JobApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
