using JobReady.Data.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    [Authorize]
    public class JobApplicationController : Controller
    {
        private readonly JobReadyContext context;
        public JobApplicationController(JobReadyContext context)
        {
            this.context = context;
        }

        #region Index
        public IActionResult Index(long jobId)
        {
            var jobApp = (from x in context.JobPost
                          where x.Id == jobId
                          select new JobPostDetails()
                          {
                              Id = x.Id,
                              CreatedById = x.CreatedById,
                              CreatedBy = new UserAccountDetails()
                              {
                                  Username = x.CreatedBy.UserName,
                                  Type = x.CreatedBy.AccountType == UserAccountType.Student ? "student" :
                                          x.CreatedBy.AccountType == UserAccountType.Instructor ? "instructor" :
                                          x.CreatedBy.AccountType == UserAccountType.Company ? "company" : "admin",
                              },
                              Description = x.Description,
                              CreatedOn = x.CreatedOn,
                              Title = x.Title,
                              IsRemote = x.IsRemote,
                              IsActive = x.IsActive,
                              HasApplied = (from y in context.JobApplication 
                                            where y.JobPostId == jobId 
                                            && y.ApplicantId == this.User.Claims.First().Value
                                            select y).Any() 
                          }).FirstOrDefault();
            jobApp.Skills = GetJobSkills(jobId);
            var userType = (from x in context.UserAccount
                            where x.Id == this.User.Claims.First().Value
                            select x.AccountType).FirstOrDefault();
            ViewData["User"] = userType;
            return View(jobApp);
        }
        #endregion

        #region Update Job Post Status
        [HttpPost]
        public IActionResult UpdateStatus([FromBody]long jobId)
        {
            var target = (from x in context.JobPost
                          where x.Id == jobId
                          select x).FirstOrDefault();
            target.IsActive = !target.IsActive;
            context.SaveChanges();
            var toast = "toast";
            return Ok(new {toast});
        }
        #endregion
        #region Get Job Skills
        private IEnumerable<SkillDetails> GetJobSkills(long jobId)
        {
            var skills = (from x in context.JobSkill
                          join y in context.Skill on x.SkillId equals y.Id
                          where x.JobPostId == jobId
                          select new SkillDetails()
                          {
                              Id = x.Id,
                              Name = y.Name
                          }).AsEnumerable();
            return skills;
        }
        #endregion
        #region Apply
        public IActionResult Apply(JobPostDetails details)
        {
            if (ModelState.IsValid)
            {
                var application = new JobApplication()
                {
                    ApplicantId = this.User.Claims.First().Value,
                    AppliedOn = DateTime.Now,
                    JobPostId = details.Id,
                    LetterOfMotivation = details.LetterOfMotivation,
                };
                context.JobApplication.Add(application);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
