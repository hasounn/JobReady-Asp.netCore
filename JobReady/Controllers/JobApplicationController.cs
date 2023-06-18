using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly JobReadyContext context;
        public JobApplicationController(JobReadyContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Apply(JobApplicationDetails details)
        {
            if(ModelState.IsValid)
            {
                var application = new JobApplication()
                {
                    ApplicantId = this.User.Claims.First().Value,
                    AppliedOn = DateTime.Now,
                    JobPostId = details.JobPostId,
                    LetterOfMotivation = details.LetterOfMotivation
                };
                context.JobApplication.Add(application);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
