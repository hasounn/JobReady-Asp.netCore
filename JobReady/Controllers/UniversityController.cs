using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobReady;
using Microsoft.AspNetCore.Authorization;

namespace JobReady.Controllers
{
    [Authorize]
    public class UniversityController : Controller
    {
        private readonly JobReadyContext context;

        public UniversityController(JobReadyContext context)
        {
            this.context = context;
        }

        // GET: University
        public async Task<IActionResult> Index()
        {
            return View(await context.University.ToListAsync());
        }

        // GET: University/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || context.University == null)
            {
                return NotFound();
            }

            var university = await context.University
                .FirstOrDefaultAsync(m => m.Id == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // GET: University/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: University/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Industry university)
        {
            if (ModelState.IsValid)
            {
                context.Add(university);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(university);
        }

        // GET: University/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || context.University == null)
            {
                return NotFound();
            }

            var university = await context.University.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }
            return View(university);
        }

        // POST: University/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] University university)
        {
            if (id != university.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(university);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityExists(university.Id))
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
            return View(university);
        }

        private bool UniversityExists(long id)
        {
            return context.University.Any(e => e.Id == id);
        }
    }
}
