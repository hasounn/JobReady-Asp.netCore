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
                        var role = (from x in context.Users where x.UserName == details.Username
                                    select x.AccountType).FirstOrDefault();
                        if(role == UserAccountType.Admin)
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        return RedirectToAction("Index", "Home"); // Replace with your desired action and controller
                    }
                }

                return RedirectToAction("Index", "Login");
            }

            return View(details);
        }

        private async void MailJetTest()
        {
            var config = (from x in context.Configuration
                          where x.Id == 1
                          select new MessageConfiguration()
                          {
                              PrivateApiKey = x.PrivateKey,
                              PublicApiKey = x.PublicKey,
                              FromAddress = "marilyn.haber@st.ul.edu.lb",
                              FromDisplayName = "JobReady",
                              IsTestMode = false
                          }).First();


            var sendProvider = new MailJetProvider(config.PublicApiKey, config.PrivateApiKey, config.FromAddress, config.FromDisplayName, config.IsTestMode);

            //            var message = new ReportMessage()
            //            {
            //                Subject = "Welcome to JobReady - Your Path to Success Starts Here!",
            //                Body = @"

            //Hey there!

            //Welcome to JobReady, the platform that connects talented individuals like you with amazing career opportunities. We are thrilled to have you join our community of motivated professionals and companies seeking top talent.

            //At JobReady, we understand the importance of finding the right opportunities to shape your future. Our mission is to empower you in your job search, provide valuable resources, and streamline the hiring process, making it easier for you to land your dream job.

            //As a new member of JobReady, you now have access to a wide range of features and tools designed to enhance your career journey. Here are some key highlights:

            //1. Create an Impressive Profile: Showcase your skills, experience, and achievements to make a strong impression on recruiters and potential employers.

            //2. Discover Exciting Job Opportunities: Explore our extensive job database tailored to your preferences and career aspirations. Find positions that match your skills and interests effortlessly.

            //3. Connect with Industry Professionals: Expand your professional network by connecting with like-minded individuals, industry experts, and recruiters who can open doors to new opportunities.

            //4. Personalized Recommendations: Receive tailored job recommendations based on your profile, skills, and preferences, ensuring you never miss out on relevant opportunities.

            //5. Stay Updated with Notifications: Be the first to know about new job openings, interview requests, and networking events through our timely notifications.

            //We are committed to your success and are continuously working to provide you with the best platform and resources to accelerate your career growth. If you have any questions, concerns, or feedback, our support team is here to assist you every step of the way.

            //Once again, welcome to JobReady! We're excited to have you on board and look forward to witnessing your achievements as you embark on this new chapter of your professional journey.

            //Best regards,

            //The JobReady Team",

            //                Recipient = "mh.marilynhaber@gmail.com",
            //            };
            //            await sendProvider.SendMessage(message, CancellationToken.None);

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

