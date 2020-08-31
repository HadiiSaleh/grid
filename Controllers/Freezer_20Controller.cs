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
    public class Freezer_20Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Freezer_20Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Freezer_20
        public async Task<IActionResult> Index()
        {
            return View(await _context.Freezer_20.ToListAsync());
        }

        // GET: Freezer_20/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezer_20 = await _context.Freezer_20
                .FirstOrDefaultAsync(m => m.Id == id);
            if (freezer_20 == null)
            {
                return NotFound();
            }

            return View(freezer_20);
        }

        // GET: Freezer_20/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Freezer_20/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Con_Id,Req_Id,Pr_Id,Box_Name,Box_Type,Level_num,Side,Lev_Side,Cons")] Freezer_20 freezer_20)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freezer_20);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(freezer_20);
        }

        // GET: Freezer_20/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezer_20 = await _context.Freezer_20.FindAsync(id);
            if (freezer_20 == null)
            {
                return NotFound();
            }
            return View(freezer_20);
        }

        // POST: Freezer_20/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Con_Id,Req_Id,Pr_Id,Box_Name,Box_Type,Level_num,Side,Lev_Side,Cons")] Freezer_20 freezer_20)
        {
            if (id != freezer_20.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freezer_20);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Freezer_20Exists(freezer_20.Id))
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
            return View(freezer_20);
        }

        // GET: Freezer_20/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezer_20 = await _context.Freezer_20
                .FirstOrDefaultAsync(m => m.Id == id);
            if (freezer_20 == null)
            {
                return NotFound();
            }

            return View(freezer_20);
        }

        // POST: Freezer_20/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var freezer_20 = await _context.Freezer_20.FindAsync(id);
            _context.Freezer_20.Remove(freezer_20);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Freezer_20Exists(int id)
        {
            return _context.Freezer_20.Any(e => e.Id == id);
        }
    }
}
