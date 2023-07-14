using JobReady.Data.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class SignUpController : Controller
    {
        private readonly JobReadyContext context;
        private readonly UserManager<UserAccount> userManager;
        private readonly SignInManager<UserAccount> signInManager;

        public SignUpController(JobReadyContext context, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserAccountDetails model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", "Login");
            }
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(UserAccountDetails details)
        {
            if (ModelState.IsValid)
            {
                details.Validate(); // Validate custom business rules
                var newUser = new UserAccount
                {
                    UserName = details.Username,
                    Email = details.Email,
                    FullName = details.FullName,
                    AccountType = details.AccountType,
                    Gender = details.Gender,
                    IndustryId = details.IndustryId,
                    Headline = details.Headline,
                    About = details.About,
                    Location = details.Location,
                    IsVerified = details.IsVerified,
                    IsEmailVerified = details.IsEmailVerified,
                    UserDate = details.UserDate,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };

                var result = await userManager.CreateAsync(newUser, details.Password);

                if (result.Succeeded)
                {
                    // Optionally, you can sign in the user after registration
                    await signInManager.SignInAsync(newUser, isPersistent: false);

                    if (details.ProfileImage != null && details.ProfileImage.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await details.ProfileImage.CopyToAsync(memoryStream);
                            if (memoryStream.Length < 2097152)
                            {
                                var newPhoto = new FileLink()
                                {
                                    ContentHash = memoryStream.ToArray(),
                                    Name = details.ProfileImage.FileName,
                                    ContentSize = details.ProfileImage.Length,
                                    ObjectType = ObjectType.UserAccount,
                                    CreatedById = newUser.Id,
                                    CreatedOn = DateTime.Now,

                                };
                                context.FileLink.Add(newPhoto);
                                context.SaveChanges();


                            }
                            else
                            {
                                ModelState.AddModelError("Photo", "The Photo is too large");
                            }
                        }
                    }
                    MailJetTest();
                    return RedirectToAction("Index", "Home"); // Replace with your desired action and controller
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
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

            var message = new ReportMessage()
            {
                Subject = "Welcome to JobReady - Your Path to Success Starts Here!",
                Body = @"

                           You just logged in! Enjoy the platform!

                            The JobReady Team",

                Recipient = "mh.marilynhaber@gmail.com",
            };

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

            await sendProvider.SendMessage(message, CancellationToken.None);
        }
    }
}
