using JobReady.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobReady;

namespace JobReady.Controllers
{
    public class JobPostController : Controller
    {

        private readonly JobReadyContext context;
        private HashSet<SkillDetails> jobSkills;

        public JobPostController(JobReadyContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(JobPostDetails details)
        {
            if (ModelState.IsValid)
            {
                var newJobPost = new JobPost
                {
                    Description = details.Description,
                    Title = details.Title,
                    JobType = details.JobType,
                    CreatedOn = details.CreatedOn,
                    CreatedBy = details.CreatedBy,
                };

                context.JobPost.Add(newJobPost);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(details);
        }
    }
}
