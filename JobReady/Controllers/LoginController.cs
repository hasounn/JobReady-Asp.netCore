using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class LoginController : Controller
    {
        private readonly JobReadyContext context;

        public LoginController(JobReadyContext context)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(LoginUserDetails user)
        //{

        //}
    }
}
