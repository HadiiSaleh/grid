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
    public class ConsumedMaterialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsumedMaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConsumedMaterials
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConsumedMaterials.ToListAsync());
        }

        // GET: ConsumedMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumedMaterials = await _context.ConsumedMaterials
                .FirstOrDefaultAsync(m => m.Con_Id == id);
            if (consumedMaterials == null)
            {
                return NotFound();
            }

            return View(consumedMaterials);
        }

        // GET: ConsumedMaterials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConsumedMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Con_Id,Exp_Id,Proj_Id,name,Quantity")] ConsumedMaterials consumedMaterials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumedMaterials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consumedMaterials);
        }

        // GET: ConsumedMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumedMaterials = await _context.ConsumedMaterials.FindAsync(id);
            if (consumedMaterials == null)
            {
                return NotFound();
            }
            return View(consumedMaterials);
        }

        // POST: ConsumedMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Con_Id,Exp_Id,Proj_Id,name,Quantity")] ConsumedMaterials consumedMaterials)
        {
            if (id != consumedMaterials.Con_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumedMaterials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumedMaterialsExists(consumedMaterials.Con_Id))
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
            return View(consumedMaterials);
        }

        // GET: ConsumedMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumedMaterials = await _context.ConsumedMaterials
                .FirstOrDefaultAsync(m => m.Con_Id == id);
            if (consumedMaterials == null)
            {
                return NotFound();
            }

            return View(consumedMaterials);
        }

        // POST: ConsumedMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumedMaterials = await _context.ConsumedMaterials.FindAsync(id);
            _context.ConsumedMaterials.Remove(consumedMaterials);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumedMaterialsExists(int id)
        {
            return _context.ConsumedMaterials.Any(e => e.Con_Id == id);
        }
    }
}
