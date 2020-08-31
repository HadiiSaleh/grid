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
    public class Project_CollaborationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Project_CollaborationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Project_Collaboration
        public async Task<IActionResult> Index()
        {
            return View(await _context.Project_Collaboration.ToListAsync());
        }

        // GET: Project_Collaboration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Collaboration = await _context.Project_Collaboration
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project_Collaboration == null)
            {
                return NotFound();
            }

            return View(project_Collaboration);
        }

        // GET: Project_Collaboration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project_Collaboration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,project_id,collaboration_id")] Project_Collaboration project_Collaboration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project_Collaboration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project_Collaboration);
        }

        // GET: Project_Collaboration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Collaboration = await _context.Project_Collaboration.FindAsync(id);
            if (project_Collaboration == null)
            {
                return NotFound();
            }
            return View(project_Collaboration);
        }

        // POST: Project_Collaboration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,project_id,collaboration_id")] Project_Collaboration project_Collaboration)
        {
            if (id != project_Collaboration.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project_Collaboration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Project_CollaborationExists(project_Collaboration.ID))
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
            return View(project_Collaboration);
        }

        // GET: Project_Collaboration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Collaboration = await _context.Project_Collaboration
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project_Collaboration == null)
            {
                return NotFound();
            }

            return View(project_Collaboration);
        }

        // POST: Project_Collaboration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project_Collaboration = await _context.Project_Collaboration.FindAsync(id);
            _context.Project_Collaboration.Remove(project_Collaboration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Project_CollaborationExists(int id)
        {
            return _context.Project_Collaboration.Any(e => e.ID == id);
        }
    }
}
