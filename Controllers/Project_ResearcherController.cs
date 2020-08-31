using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MicrobiologyLab.Data;
using MicrobiologyLab.Models;

namespace MicrobiologyLab.Controllers
{
    public class Project_ResearcherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Project_ResearcherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Project_Researcher
        public async Task<IActionResult> Index()
        {
            return View(await _context.Project_Researcher.ToListAsync());
        }

        // GET: Project_Researcher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Researcher = await _context.Project_Researcher
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project_Researcher == null)
            {
                return NotFound();
            }

            return View(project_Researcher);
        }

        // GET: Project_Researcher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project_Researcher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,project_id,researcher_id")] Project_Researcher project_Researcher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project_Researcher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project_Researcher);
        }

        // GET: Project_Researcher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Researcher = await _context.Project_Researcher.FindAsync(id);
            if (project_Researcher == null)
            {
                return NotFound();
            }
            return View(project_Researcher);
        }

        // POST: Project_Researcher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,project_id,researcher_id")] Project_Researcher project_Researcher)
        {
            if (id != project_Researcher.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project_Researcher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Project_ResearcherExists(project_Researcher.ID))
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
            return View(project_Researcher);
        }

        // GET: Project_Researcher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Researcher = await _context.Project_Researcher
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project_Researcher == null)
            {
                return NotFound();
            }

            return View(project_Researcher);
        }

        // POST: Project_Researcher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project_Researcher = await _context.Project_Researcher.FindAsync(id);
            _context.Project_Researcher.Remove(project_Researcher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Project_ResearcherExists(int id)
        {
            return _context.Project_Researcher.Any(e => e.ID == id);
        }
    }
}
