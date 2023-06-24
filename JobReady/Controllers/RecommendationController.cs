using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly JobReadyContext context;
        public RecommendationController(JobReadyContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddRecommendation([FromBody] string instructorId)
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
    }
}
