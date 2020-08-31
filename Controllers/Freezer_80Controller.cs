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
    public class Freezer_80Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Freezer_80Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Freezer_80
        public async Task<IActionResult> Index()
        {
            return View(await _context.Freezer_80.ToListAsync());
        }

        // GET: Freezer_80/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezer_80 = await _context.Freezer_80
                .FirstOrDefaultAsync(m => m.Id == id);
            if (freezer_80 == null)
            {
                return NotFound();
            }

            return View(freezer_80);
        }

        // GET: Freezer_80/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Freezer_80/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Con_Id,Req_Id,Pr_Id,Box_Name,Box_Type,Level_num,Side,Lev_Side,Col7")] Freezer_80 freezer_80)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freezer_80);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(freezer_80);
        }

        // GET: Freezer_80/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezer_80 = await _context.Freezer_80.FindAsync(id);
            if (freezer_80 == null)
            {
                return NotFound();
            }
            return View(freezer_80);
        }

        // POST: Freezer_80/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Con_Id,Req_Id,Pr_Id,Box_Name,Box_Type,Level_num,Side,Lev_Side,Col7")] Freezer_80 freezer_80)
        {
            if (id != freezer_80.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freezer_80);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Freezer_80Exists(freezer_80.Id))
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
            return View(freezer_80);
        }

        // GET: Freezer_80/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freezer_80 = await _context.Freezer_80
                .FirstOrDefaultAsync(m => m.Id == id);
            if (freezer_80 == null)
            {
                return NotFound();
            }

            return View(freezer_80);
        }

        // POST: Freezer_80/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var freezer_80 = await _context.Freezer_80.FindAsync(id);
            _context.Freezer_80.Remove(freezer_80);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Freezer_80Exists(int id)
        {
            return _context.Freezer_80.Any(e => e.Id == id);
        }
    }
}
