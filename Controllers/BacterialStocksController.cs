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
    public class BacterialStocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BacterialStocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BacterialStocks
        public async Task<IActionResult> Index()
        {
            return View(await _context.BacterialStock.ToListAsync());
        }

        // GET: BacterialStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacterialStock = await _context.BacterialStock
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bacterialStock == null)
            {
                return NotFound();
            }

            return View(bacterialStock);
        }

        // GET: BacterialStocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BacterialStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Box_Name,Bacteria_Name,x,y,Con_Id,Pr_Id,Req_Id")] BacterialStock bacterialStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bacterialStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bacterialStock);
        }

        // GET: BacterialStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacterialStock = await _context.BacterialStock.FindAsync(id);
            if (bacterialStock == null)
            {
                return NotFound();
            }
            return View(bacterialStock);
        }

        // POST: BacterialStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Box_Name,Bacteria_Name,x,y,Con_Id,Pr_Id,Req_Id")] BacterialStock bacterialStock)
        {
            if (id != bacterialStock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bacterialStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BacterialStockExists(bacterialStock.Id))
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
            return View(bacterialStock);
        }

        // GET: BacterialStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacterialStock = await _context.BacterialStock
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bacterialStock == null)
            {
                return NotFound();
            }

            return View(bacterialStock);
        }

        // POST: BacterialStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bacterialStock = await _context.BacterialStock.FindAsync(id);
            _context.BacterialStock.Remove(bacterialStock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BacterialStockExists(int id)
        {
            return _context.BacterialStock.Any(e => e.Id == id);
        }
    }
}
