using JobReady.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace JobReady.Controllers
{
    public class SignUpController : Controller
    {
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
    }
}
