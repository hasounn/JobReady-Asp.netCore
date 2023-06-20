using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class AdminController : Controller
    {
        private readonly JobReadyContext context;
        public AdminController(JobReadyContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
