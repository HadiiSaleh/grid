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
    public class RequiredMaterialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequiredMaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RequiredMaterials
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RequiredMaterial.Include(r => r.Experiment);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RequiredMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requiredMaterial = await _context.RequiredMaterial
                .Include(r => r.Experiment)
                .FirstOrDefaultAsync(m => m.reqmat_id == id);
            if (requiredMaterial == null)
            {
                return NotFound();
            }

            return View(requiredMaterial);
        }

        // GET: RequiredMaterials/Create
        public IActionResult Create()
        {
            ViewData["ex_id"] = new SelectList(_context.Experiment, "Exp_Id", "Exp_Id");
            return View();
        }

        // POST: RequiredMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("reqmat_id,name1,quantity,ex_id")] RequiredMaterial requiredMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requiredMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ex_id"] = new SelectList(_context.Experiment, "Exp_Id", "Exp_Id", requiredMaterial.ex_id);
            return View(requiredMaterial);
        }

        // GET: RequiredMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requiredMaterial = await _context.RequiredMaterial.FindAsync(id);
            if (requiredMaterial == null)
            {
                return NotFound();
            }
            ViewData["ex_id"] = new SelectList(_context.Experiment, "Exp_Id", "Exp_Id", requiredMaterial.ex_id);
            return View(requiredMaterial);
        }

        // POST: RequiredMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("reqmat_id,name1,quantity,ex_id")] RequiredMaterial requiredMaterial)
        {
            if (id != requiredMaterial.reqmat_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requiredMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequiredMaterialExists(requiredMaterial.reqmat_id))
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
            ViewData["ex_id"] = new SelectList(_context.Experiment, "Exp_Id", "Exp_Id", requiredMaterial.ex_id);
            return View(requiredMaterial);
        }

        // GET: RequiredMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requiredMaterial = await _context.RequiredMaterial
                .Include(r => r.Experiment)
                .FirstOrDefaultAsync(m => m.reqmat_id == id);
            if (requiredMaterial == null)
            {
                return NotFound();
            }

            return View(requiredMaterial);
        }

        // POST: RequiredMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requiredMaterial = await _context.RequiredMaterial.FindAsync(id);
            _context.RequiredMaterial.Remove(requiredMaterial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequiredMaterialExists(int id)
        {
            return _context.RequiredMaterial.Any(e => e.reqmat_id == id);
        }
    }
}
