using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    [Authorize]
    public class ApplicantsController : Controller
    {
        private readonly JobReadyContext context;

        public ApplicantsController(JobReadyContext context)
        {
            this.context = context;
        }
        public ActionResult Index(long jobId)
        {

            var applications = (from x in context.JobPost
                                join y in context.JobApplication on x.Id equals y.JobPostId into apps
                                from a in apps.DefaultIfEmpty()
                                where x.Id == jobId
                                select new JobApplicationDetails()
                                {
                                    Id = a.Id,
                                    ApplicantId = a.ApplicantId,
                                    Applicant = new UserAccountDetails()
                                    {
                                        Id = a.Applicant.Id,
                                        FullName = a.Applicant.FullName,
                                        Username = a.Applicant.UserName,
                                    },
                                    JobPost = new JobPostDetails()
                                    {
                                        Title = x.Title,
                                    },
                                    LetterOfMotivation = a.LetterOfMotivation,
                                }).AsQueryable();
            var userType = (from x in context.UserAccount
                            where x.Id == this.User.Claims.First().Value
                            select x.AccountType).FirstOrDefault();
            ViewData["User"] = userType;

            return View(applications);
        }
    }
}
