using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    [Authorize]
    public class LogoutController : Controller
    {
        private readonly JobReadyContext context;
        private readonly SignInManager<UserAccount> signInManager;

        public LogoutController(JobReadyContext context, SignInManager<UserAccount> signInManager)
        {
            this.signInManager = signInManager;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var test = this.User;
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
