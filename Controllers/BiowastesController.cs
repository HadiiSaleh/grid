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
    public class BiowastesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BiowastesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Biowastes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Biowaste.ToListAsync());
        }

        // GET: Biowastes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biowaste = await _context.Biowaste
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biowaste == null)
            {
                return NotFound();
            }

            return View(biowaste);
        }

        // GET: Biowastes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Biowastes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comp_Id,Box_num,weight")] Biowaste biowaste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biowaste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biowaste);
        }

        // GET: Biowastes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biowaste = await _context.Biowaste.FindAsync(id);
            if (biowaste == null)
            {
                return NotFound();
            }
            return View(biowaste);
        }

        // POST: Biowastes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Comp_Id,Box_num,weight")] Biowaste biowaste)
        {
            if (id != biowaste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biowaste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiowasteExists(biowaste.Id))
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
            return View(biowaste);
        }

        // GET: Biowastes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biowaste = await _context.Biowaste
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biowaste == null)
            {
                return NotFound();
            }

            return View(biowaste);
        }

        // POST: Biowastes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biowaste = await _context.Biowaste.FindAsync(id);
            _context.Biowaste.Remove(biowaste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiowasteExists(int id)
        {
            return _context.Biowaste.Any(e => e.Id == id);
        }
    }
}
