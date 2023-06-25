using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class ApplicantsController : Controller
    {
        private readonly JobReadyContext context;

        public ApplicantsController(JobReadyContext context)
        {
            this.context = context;
        }
        public ActionResult Index(long jobId)
        {
            var applicants = (from x in context.JobApplication
                              where x.JobPostId == jobId
                              select new JobApplicationDetails()
                              {
                                  Id = jobId,
                                  ApplicantId = x.ApplicantId,
                                  Applicant = new UserAccountDetails()
                                  {
                                      Id = x.Applicant.Id,
                                      FullName = x.Applicant.FullName,
                                      Username = x.Applicant.UserName,
                                  },
                                  JobPost = new JobPostDetails()
                                  {
                                      Title = x.JobPost.Title,
                                  },
                                  LetterOfMotivation = x.LetterOfMotivation,
                              }).AsQueryable();
            var userType = (from x in context.UserAccount
                            where x.Id == this.User.Claims.First().Value
                            select x.AccountType).FirstOrDefault();
            ViewData["User"] = userType;
            return View(applicants);
        }
    }
}
