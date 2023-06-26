using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JobReady.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly JobReadyContext _context;

        public CompanyController(JobReadyContext context)
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
            return View(await _context.UserAccount.Where(t=>t.AccountType == UserAccountType.Company).ToListAsync());
        }

        // GET: University/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Home");
            if (id == null || _context.UserAccount == null)
            {
                return NotFound();
            }

            var company = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: University/Create
        public IActionResult Create()
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Home");
            return View();
        }

        // POST: University/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,HeadQuarterLocation,BranchesCount")] UserAccount company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: University/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Home");
            if (id == null || _context.UserAccount == null)
            {
                return NotFound();
            }

            var company = await _context.UserAccount.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: University/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,HeadQuarterLocation,BranchesCount")] UserAccount company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: University/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Home");
            if (id == null || _context.UserAccount == null)
            {
                return NotFound();
            }

            var company = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: University/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.University == null)
            {
                return Problem("Entity set 'JobReadyContext.UserAccount'  is null.");
            }
            var company = await _context.UserAccount.FindAsync(id);
            if (company != null)
            {
                _context.UserAccount.Remove(company);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(string id)
        {
            return _context.UserAccount.Any(e => e.Id == id && e.AccountType == UserAccountType.Company);
        }
    }
}
