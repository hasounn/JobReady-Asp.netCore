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

            var image = "/icons/tick-white.svg";
            return Ok(new {image});
        }
    }
}
