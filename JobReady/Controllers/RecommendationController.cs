using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    [Authorize]
    public class RecommendationController : Controller
    {
        private readonly JobReadyContext context;
        public RecommendationController(JobReadyContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddRecommendationRequest([FromBody] string instructorId)
        {
            var askForRecommendation = new Recommendation()
            {
                StudentId = this.User.Claims.First().Value,
                InstructorId = instructorId,
                Status = RecommendationStatus.Pending,
                RequestDate = DateTime.Now
            };
            context.Recommendation.Add(askForRecommendation);
            context.SaveChanges();

            var image = "/icons/tick-white.svg";
            return Ok(new {image});
        }

        [HttpGet]
        public IActionResult RejectRecommendation(long id)
        {
            var instructorId = (from x in context.UserAccount
                                where x.Id == this.User.Claims.First().Value
                                && x.AccountType == UserAccountType.Instructor
                                select x).FirstOrDefault();
            if(instructorId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var target = (from x in context.Recommendation
                          where x.Id == id
                          select x).FirstOrDefault();
            target.Status = RecommendationStatus.Rejected;
            target.ResponseDate = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("Index", "Notifications", new { view = "_RecommendationView" });
        }

        [HttpPost]
        public IActionResult AcceptRecommendation(RecommendationReply details)
        {
            var instructorId = (from x in context.UserAccount
                                where x.Id == this.User.Claims.First().Value
                                && x.AccountType == UserAccountType.Instructor
                                select x).FirstOrDefault();
            if (instructorId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var target = (from x in context.Recommendation
                          where x.Id == details.Id
                          select x).FirstOrDefault();
            target.Status = RecommendationStatus.Accepted;
            target.ResponseDate = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("Index", "Notifications", new { view = "_RecommendationView" });
        }
    }
}
