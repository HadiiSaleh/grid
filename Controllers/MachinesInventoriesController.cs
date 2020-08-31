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
    public class MachinesInventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MachinesInventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MachinesInventories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MachinesInventory.Include(m => m.incomingProduct).Include(m => m.user);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MachinesInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinesInventory = await _context.MachinesInventory
                .Include(m => m.incomingProduct)
                .Include(m => m.user)
                .FirstOrDefaultAsync(m => m.mid == id);
            if (machinesInventory == null)
            {
                return NotFound();
            }

            return View(machinesInventory);
        }

        // GET: MachinesInventories/Create
        public IActionResult Create()
        {
            ViewData["pr_id"] = new SelectList(_context.IncomingProduct, "pr_id", "additionnalNotes");
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: MachinesInventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mid,furniture_name,quantity_micro,quantity_mol,quantity_cell,quantity_myco,quantity_storage,quantity_refrig,quantity_meeting,total,id,pr_id")] MachinesInventory machinesInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machinesInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["pr_id"] = new SelectList(_context.IncomingProduct, "pr_id", "additionnalNotes", machinesInventory.pr_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", machinesInventory.id);
            return View(machinesInventory);
        }

        // GET: MachinesInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinesInventory = await _context.MachinesInventory.FindAsync(id);
            if (machinesInventory == null)
            {
                return NotFound();
            }
            ViewData["pr_id"] = new SelectList(_context.IncomingProduct, "pr_id", "additionnalNotes", machinesInventory.pr_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", machinesInventory.id);
            return View(machinesInventory);
        }

        // POST: MachinesInventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mid,furniture_name,quantity_micro,quantity_mol,quantity_cell,quantity_myco,quantity_storage,quantity_refrig,quantity_meeting,total,id,pr_id")] MachinesInventory machinesInventory)
        {
            if (id != machinesInventory.mid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machinesInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachinesInventoryExists(machinesInventory.mid))
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
            ViewData["pr_id"] = new SelectList(_context.IncomingProduct, "pr_id", "additionnalNotes", machinesInventory.pr_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", machinesInventory.id);
            return View(machinesInventory);
        }

        // GET: MachinesInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinesInventory = await _context.MachinesInventory
                .Include(m => m.incomingProduct)
                .Include(m => m.user)
                .FirstOrDefaultAsync(m => m.mid == id);
            if (machinesInventory == null)
            {
                return NotFound();
            }

            return View(machinesInventory);
        }

        // POST: MachinesInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machinesInventory = await _context.MachinesInventory.FindAsync(id);
            _context.MachinesInventory.Remove(machinesInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachinesInventoryExists(int id)
        {
            return _context.MachinesInventory.Any(e => e.mid == id);
        }
    }
}
