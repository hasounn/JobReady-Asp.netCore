﻿using JobReady.Data.DTO;
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
                          join z in context.UserAccount on x.CreatedById equals z.Id
                          join js in context.JobSkill on x.Id equals js.Id
                          join s in context.Skill on js.SkillId equals s.Id
                          where x.Id == jobId
                          select new JobPostDetails()
                          {
                              Id = x.Id,
                              CreatedById = x.CreatedById,
                              CreatedBy = new UserAccountDetails()
                              {
                                  Username = z.UserName,
                                  AccountType = z.AccountType,
                              },
                              Description = x.Description,
                              CreatedOn = x.CreatedOn,
                              Title = x.Title,
                              IsRemote = x.IsRemote,
                              Skills = new List<SkillDetails>()
                                      {
                                            new SkillDetails()
                                            {
                                                      Id = s.Id,
                                                      Name = s.Name
                                            }
                                      }.AsEnumerable() ,
                              HasApplied = (from x in context.JobApplication 
                                            where x.JobPostId == jobId 
                                            && x.ApplicantId == this.User.Claims.First().Value
                                            select x).Any() 
                          }).FirstOrDefault();
            return View(jobApp);
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
