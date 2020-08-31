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
    public class ConsumablesInventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsumablesInventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConsumablesInventories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConsumablesInventory.ToListAsync());
        }

        // GET: ConsumablesInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumablesInventory = await _context.ConsumablesInventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumablesInventory == null)
            {
                return NotFound();
            }

            return View(consumablesInventory);
        }

        // GET: ConsumablesInventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConsumablesInventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fur_Name,Quantity_micro,Quantity_mol,Quantity_cell,Quantity_myco,Quantity_storage,Quantity_Refrig,Quantity_meeting,Total,Req_Id,Pr_Id,User_Id")] ConsumablesInventory consumablesInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumablesInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consumablesInventory);
        }

        // GET: ConsumablesInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumablesInventory = await _context.ConsumablesInventory.FindAsync(id);
            if (consumablesInventory == null)
            {
                return NotFound();
            }
            return View(consumablesInventory);
        }

        // POST: ConsumablesInventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fur_Name,Quantity_micro,Quantity_mol,Quantity_cell,Quantity_myco,Quantity_storage,Quantity_Refrig,Quantity_meeting,Total,Req_Id,Pr_Id,User_Id")] ConsumablesInventory consumablesInventory)
        {
            if (id != consumablesInventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumablesInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumablesInventoryExists(consumablesInventory.Id))
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
            return View(consumablesInventory);
        }

        // GET: ConsumablesInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumablesInventory = await _context.ConsumablesInventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumablesInventory == null)
            {
                return NotFound();
            }

            return View(consumablesInventory);
        }

        // POST: ConsumablesInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumablesInventory = await _context.ConsumablesInventory.FindAsync(id);
            _context.ConsumablesInventory.Remove(consumablesInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumablesInventoryExists(int id)
        {
            return _context.ConsumablesInventory.Any(e => e.Id == id);
        }
    }
}
