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
        public IActionResult AddRecommendation([FromBody] long instructorId)
        {
            return Ok(true); ;
        }
    }
}
