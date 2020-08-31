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
    public class FurnituresInventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FurnituresInventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FurnituresInventories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FurnituresInventory.Include(f => f.incomingProduct).Include(f => f.requiredMaterial).Include(f => f.user);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FurnituresInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furnituresInventory = await _context.FurnituresInventory
                .Include(f => f.incomingProduct)
                .Include(f => f.requiredMaterial)
                .Include(f => f.user)
                .FirstOrDefaultAsync(m => m.fid == id);
            if (furnituresInventory == null)
            {
                return NotFound();
            }

            return View(furnituresInventory);
        }

        // GET: FurnituresInventories/Create
        public IActionResult Create()
        {
            ViewData["pr_id"] = new SelectList(_context.Set<IncomingProduct>(), "pr_id", "additionnalNotes");
            ViewData["reqmat_id"] = new SelectList(_context.Set<RequiredMaterial>(), "reqmat_id", "name1");
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: FurnituresInventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("fid,furniture_name,quantity_micro,quantity_mol,quantity_cell,quantity_myco,quantity_storage,quantity_refrig,quantity_meeting,total,id,pr_id,reqmat_id")] FurnituresInventory furnituresInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(furnituresInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["pr_id"] = new SelectList(_context.Set<IncomingProduct>(), "pr_id", "additionnalNotes", furnituresInventory.pr_id);
            ViewData["reqmat_id"] = new SelectList(_context.Set<RequiredMaterial>(), "reqmat_id", "name1", furnituresInventory.reqmat_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", furnituresInventory.id);
            return View(furnituresInventory);
        }

        // GET: FurnituresInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furnituresInventory = await _context.FurnituresInventory.FindAsync(id);
            if (furnituresInventory == null)
            {
                return NotFound();
            }
            ViewData["pr_id"] = new SelectList(_context.Set<IncomingProduct>(), "pr_id", "additionnalNotes", furnituresInventory.pr_id);
            ViewData["reqmat_id"] = new SelectList(_context.Set<RequiredMaterial>(), "reqmat_id", "name1", furnituresInventory.reqmat_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", furnituresInventory.id);
            return View(furnituresInventory);
        }

        // POST: FurnituresInventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("fid,furniture_name,quantity_micro,quantity_mol,quantity_cell,quantity_myco,quantity_storage,quantity_refrig,quantity_meeting,total,id,pr_id,reqmat_id")] FurnituresInventory furnituresInventory)
        {
            if (id != furnituresInventory.fid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(furnituresInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FurnituresInventoryExists(furnituresInventory.fid))
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
            ViewData["pr_id"] = new SelectList(_context.Set<IncomingProduct>(), "pr_id", "additionnalNotes", furnituresInventory.pr_id);
            ViewData["reqmat_id"] = new SelectList(_context.Set<RequiredMaterial>(), "reqmat_id", "name1", furnituresInventory.reqmat_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", furnituresInventory.id);
            return View(furnituresInventory);
        }

        // GET: FurnituresInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var furnituresInventory = await _context.FurnituresInventory
                .Include(f => f.incomingProduct)
                .Include(f => f.requiredMaterial)
                .Include(f => f.user)
                .FirstOrDefaultAsync(m => m.fid == id);
            if (furnituresInventory == null)
            {
                return NotFound();
            }

            return View(furnituresInventory);
        }

        // POST: FurnituresInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var furnituresInventory = await _context.FurnituresInventory.FindAsync(id);
            _context.FurnituresInventory.Remove(furnituresInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FurnituresInventoryExists(int id)
        {
            return _context.FurnituresInventory.Any(e => e.fid == id);
        }
    }
}
