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



            var configuration = new ConfigurationBuilder()
            .AddUserSecrets<LoginController>()
            .Build();
            privateApiKey = configuration["PrivateApiKey"];
            publicApiKey = configuration["PublicApiKey"];
            fromAddress = configuration["FromAddress"];
        }
        readonly string privateApiKey;
        readonly string publicApiKey;
        readonly string fromAddress;

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

             MailJetTest();
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
                        return RedirectToAction("Index", "Home"); // Replace with your desired action and controller
                    }
                }

                return RedirectToAction("Index", "Login");
            }

            return View(details);
        }


        private async void MailJetTest()
        {
            var sendProvider = new MailJetProvider(publicApiKey, privateApiKey, fromAddress, "Testing", false);

            var message = new ReportMessage()
            {
                Subject = "TESTING",
                Body = "This is a testing message. Please ignore if received.",
                Recipient = "mh.marilynhaber@gmail.com"
            };
            await sendProvider.SendMessage(message, CancellationToken.None);
        }
    }
}
