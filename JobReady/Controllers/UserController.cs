using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JobReady.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly JobReadyContext _context;

        public UserController(JobReadyContext context)
        {
            _context = context;
        }
        private bool IsAdmin()
        {
            var userType = (from x in _context.Users
                            where x.Id == this.User.Claims.First().Value
                            select x.AccountType).FirstOrDefault();
            return (userType == UserAccountType.Admin);
        }
        // GET: Company
        public async Task<IActionResult> Index()
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Home");
            return View(await _context.UserAccount.Where(t => t.AccountType == UserAccountType.Instructor || t.AccountType == UserAccountType.Student).ToListAsync());
        }
    }
}