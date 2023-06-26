using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly JobReadyContext context;
        public AdminController(JobReadyContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var userType = (from x in context.Users
                        where x.Id == this.User.Claims.First().Value
                        select x.AccountType).FirstOrDefault();
            if(userType != UserAccountType.Admin)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
