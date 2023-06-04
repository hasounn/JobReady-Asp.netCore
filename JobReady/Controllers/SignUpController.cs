using JobReady.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class SignUpController : Controller
    {
        private readonly JobReadyContext context;
        public SignUpController(JobReadyContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SignUpUserRegistry model)
        {
            if(ModelState.IsValid)
            {
                
                return RedirectToAction("Index","Login");
            }
            return View(model);

        }

        [HttpPost]
        public IActionResult Create(UserAccountDetails source)
        {
            source.Validate();
            var existing = (from x in context.UserAccount
                            where
                            x.Email == source.Email
                            && x.IsEmailVerified
                            || x.Username == source.Username
                            select x);
            if(existing.Any())
            {
                throw new Exception("This user already exists");
            }
            var target = new UserAccount()
            {
                About = source.About,
                AccountType = source.AccountType,
                Email = source.Email,
                UserDate = source.UserDate,
                FullName = source.FullName,
                Username = source.Username,
                Password = source.Password,
                PhoneNumber = source.PhoneNumber,
                Headline = source.Headline,
                Gender = source.Gender,
                IsEmailVerified = source.IsEmailVerified,
                IsVerified = source.IsVerified,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                Location = source.Location,
                IndustryId = source.IndustryId
            };
            context.Add(target);
            context.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }

    }
}
