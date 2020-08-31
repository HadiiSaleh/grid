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
    public class ItemsInventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsInventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemsInventories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ItemsInventory.Include(i => i.incomingProduct).Include(i => i.requiredMaterial).Include(i => i.user);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ItemsInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsInventory = await _context.ItemsInventory
                .Include(i => i.incomingProduct)
                .Include(i => i.requiredMaterial)
                .Include(i => i.user)
                .FirstOrDefaultAsync(m => m.iid == id);
            if (itemsInventory == null)
            {
                return NotFound();
            }

            return View(itemsInventory);
        }

        // GET: ItemsInventories/Create
        public IActionResult Create()
        {
            ViewData["pr_id"] = new SelectList(_context.IncomingProduct, "pr_id", "additionnalNotes");
            ViewData["reqmat_id"] = new SelectList(_context.Set<RequiredMaterial>(), "reqmat_id", "name1");
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: ItemsInventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iid,item_name,quantity_micro,quantity_mol,quantity_cell,quantity_myco,quantity_storage,quantity_refrig,quantity_meeting,total,id,pr_id,reqmat_id")] ItemsInventory itemsInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemsInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["pr_id"] = new SelectList(_context.IncomingProduct, "pr_id", "additionnalNotes", itemsInventory.pr_id);
            ViewData["reqmat_id"] = new SelectList(_context.Set<RequiredMaterial>(), "reqmat_id", "name1", itemsInventory.reqmat_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", itemsInventory.id);
            return View(itemsInventory);
        }

        // GET: ItemsInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsInventory = await _context.ItemsInventory.FindAsync(id);
            if (itemsInventory == null)
            {
                return NotFound();
            }
            ViewData["pr_id"] = new SelectList(_context.IncomingProduct, "pr_id", "additionnalNotes", itemsInventory.pr_id);
            ViewData["reqmat_id"] = new SelectList(_context.Set<RequiredMaterial>(), "reqmat_id", "name1", itemsInventory.reqmat_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", itemsInventory.id);
            return View(itemsInventory);
        }

        // POST: ItemsInventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iid,item_name,quantity_micro,quantity_mol,quantity_cell,quantity_myco,quantity_storage,quantity_refrig,quantity_meeting,total,id,pr_id,reqmat_id")] ItemsInventory itemsInventory)
        {
            if (id != itemsInventory.iid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemsInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsInventoryExists(itemsInventory.iid))
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
            ViewData["pr_id"] = new SelectList(_context.IncomingProduct, "pr_id", "additionnalNotes", itemsInventory.pr_id);
            ViewData["reqmat_id"] = new SelectList(_context.Set<RequiredMaterial>(), "reqmat_id", "name1", itemsInventory.reqmat_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", itemsInventory.id);
            return View(itemsInventory);
        }

        // GET: ItemsInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsInventory = await _context.ItemsInventory
                .Include(i => i.incomingProduct)
                .Include(i => i.requiredMaterial)
                .Include(i => i.user)
                .FirstOrDefaultAsync(m => m.iid == id);
            if (itemsInventory == null)
            {
                return NotFound();
            }

            return View(itemsInventory);
        }

        // POST: ItemsInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemsInventory = await _context.ItemsInventory.FindAsync(id);
            _context.ItemsInventory.Remove(itemsInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsInventoryExists(int id)
        {
            return _context.ItemsInventory.Any(e => e.iid == id);
        }
    }
}
