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
    public class OpeningAndClosingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpeningAndClosingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OpeningAndClosings
        public async Task<IActionResult> Index()
        {
            return View(await _context.OpeningAndClosing.ToListAsync());
        }

        // GET: OpeningAndClosings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openingAndClosing = await _context.OpeningAndClosing
                .FirstOrDefaultAsync(m => m.oc_id == id);
            if (openingAndClosing == null)
            {
                return NotFound();
            }

            return View(openingAndClosing);
        }

        // GET: OpeningAndClosings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OpeningAndClosings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("oc_id,opening_time,closing_time,Date")] OpeningAndClosing openingAndClosing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(openingAndClosing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(openingAndClosing);
        }

        // GET: OpeningAndClosings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openingAndClosing = await _context.OpeningAndClosing.FindAsync(id);
            if (openingAndClosing == null)
            {
                return NotFound();
            }
            return View(openingAndClosing);
        }

        // POST: OpeningAndClosings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("oc_id,opening_time,closing_time,Date")] OpeningAndClosing openingAndClosing)
        {
            if (id != openingAndClosing.oc_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(openingAndClosing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpeningAndClosingExists(openingAndClosing.oc_id))
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
            return View(openingAndClosing);
        }

        // GET: OpeningAndClosings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openingAndClosing = await _context.OpeningAndClosing
                .FirstOrDefaultAsync(m => m.oc_id == id);
            if (openingAndClosing == null)
            {
                return NotFound();
            }

            return View(openingAndClosing);
        }

        // POST: OpeningAndClosings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var openingAndClosing = await _context.OpeningAndClosing.FindAsync(id);
            _context.OpeningAndClosing.Remove(openingAndClosing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpeningAndClosingExists(int id)
        {
            return _context.OpeningAndClosing.Any(e => e.oc_id == id);
        }
    }
}
