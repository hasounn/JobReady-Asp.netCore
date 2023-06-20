using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class LoginController : Controller
    {
        private readonly JobReadyContext context;
        private readonly SignInManager<UserAccount> signInManager;

        public LoginController(JobReadyContext context, SignInManager<UserAccount> signInManager)
        {
            this.signInManager = signInManager;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDetails details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(details.Username, details.Password, details.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        var role = (from x in context.Users where x.UserName == this.User.Identity.Name
                                    select x.AccountType).FirstOrDefault();
                        if(role == UserAccountType.Admin)
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        return RedirectToAction("Index", "Home"); // Replace with your desired action and controller
                    }
                }

                return RedirectToAction("Index", "Home");
            }

            return View(details);
        }
    }
}
