using JobReady.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class SignUpController : Controller
    {
        private readonly JobReadyContext context;
        public SignUpController(JobReadyContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SignUpUserRegistry model)
        {
            if(ModelState.IsValid)
            {
                
                return RedirectToAction("Index","Login");
            }
            return View(model);

        }

        [HttpPost]
        public IActionResult Create(UserAccountDetails source)
        {
            source.Validate();
            return RedirectToAction("Index");
        }

    }
}
