using JobReady.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobReady;
using System.Transactions;
using System;

namespace JobReady.Controllers
{
    public class JobPostController : Controller
    {

        private readonly JobReadyContext context;
        private static HashSet<long> jobSkills = new ();

        public JobPostController(JobReadyContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(new JobPostDetails() { Skills = GetSkills()});
        }

        [HttpGet]
        public IEnumerable<SkillDetails> GetSkills()
        {
            var skills = (from x in context.Skill
                          select new SkillDetails()
                          {
                              Id = x.Id,
                              Name = x.Name,
                          }).AsEnumerable();
            return skills;
        }

        [HttpPost]
        public IActionResult AddSkill([FromBody] long skillId)
        {
                jobSkills.Add(skillId);
                return Ok(true);
        }

        [HttpPost]
        public IActionResult FindSkill([FromBody] long skillId)
        {
           bool found = jobSkills.Any(t => t == skillId);
            return Ok(found);
        }

        [HttpPost]
        public IActionResult Create(JobPostDetails details)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var newJobPost = new JobPost
                    {
                        Description = details.Description,
                        Title = details.Title,
                        JobType = details.JobType,
                        IsActive = details.IsActive,
                        CreatedById = this.User.Claims.First().Value,
                        CreatedOn = DateTime.Now,
                    };

                    context.JobPost.Add(newJobPost);
                    context.SaveChanges();

                    foreach(var skill in jobSkills)
                    {
                        var newSkill = new JobSkill()
                        {
                            JobPostId = newJobPost.Id,
                            SkillId = skill,
                        };
                        context.JobSkill.Add(newSkill);
                        context.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(details);
        }
    }
}
