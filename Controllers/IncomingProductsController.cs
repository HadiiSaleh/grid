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
    public class IncomingProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncomingProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IncomingProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IncomingProduct.Include(i => i.company).Include(i => i.user);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IncomingProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomingProduct = await _context.IncomingProduct
                .Include(i => i.company)
                .Include(i => i.user)
                .FirstOrDefaultAsync(m => m.pr_id == id);
            if (incomingProduct == null)
            {
                return NotFound();
            }

            return View(incomingProduct);
        }

        // GET: IncomingProducts/Create
        public IActionResult Create()
        {
            ViewData["comp_id"] = new SelectList(_context.Company, "Comp_Id", "Comp_Id");
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: IncomingProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pr_id,name,quantity,weight,exdate,additionnalNotes,arrdate,id,comp_id")] IncomingProduct incomingProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incomingProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["comp_id"] = new SelectList(_context.Company, "Comp_Id", "Comp_Id", incomingProduct.comp_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", incomingProduct.id);
            return View(incomingProduct);
        }

        // GET: IncomingProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomingProduct = await _context.IncomingProduct.FindAsync(id);
            if (incomingProduct == null)
            {
                return NotFound();
            }
            ViewData["comp_id"] = new SelectList(_context.Company, "Comp_Id", "Comp_Id", incomingProduct.comp_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", incomingProduct.id);
            return View(incomingProduct);
        }

        // POST: IncomingProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pr_id,name,quantity,weight,exdate,additionnalNotes,arrdate,id,comp_id")] IncomingProduct incomingProduct)
        {
            if (id != incomingProduct.pr_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomingProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomingProductExists(incomingProduct.pr_id))
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
            ViewData["comp_id"] = new SelectList(_context.Company, "Comp_Id", "Comp_Id", incomingProduct.comp_id);
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", incomingProduct.id);
            return View(incomingProduct);
        }

        // GET: IncomingProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomingProduct = await _context.IncomingProduct
                .Include(i => i.company)
                .Include(i => i.user)
                .FirstOrDefaultAsync(m => m.pr_id == id);
            if (incomingProduct == null)
            {
                return NotFound();
            }

            return View(incomingProduct);
        }

        // POST: IncomingProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incomingProduct = await _context.IncomingProduct.FindAsync(id);
            _context.IncomingProduct.Remove(incomingProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomingProductExists(int id)
        {
            return _context.IncomingProduct.Any(e => e.pr_id == id);
        }
    }
}
