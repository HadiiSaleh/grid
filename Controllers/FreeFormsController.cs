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
    public class FreeFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FreeFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FreeForms
        public async Task<IActionResult> Index()
        {
            return View(await _context.FreeForm.ToListAsync());
        }

        // GET: FreeForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freeForm = await _context.FreeForm
                .FirstOrDefaultAsync(m => m.ff_Id == id);
            if (freeForm == null)
            {
                return NotFound();
            }

            return View(freeForm);
        }

        // GET: FreeForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FreeForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ff_Id,User_Id,acceptance")] FreeForm freeForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freeForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(freeForm);
        }

        // GET: FreeForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freeForm = await _context.FreeForm.FindAsync(id);
            if (freeForm == null)
            {
                return NotFound();
            }
            return View(freeForm);
        }

        // POST: FreeForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ff_Id,User_Id,acceptance")] FreeForm freeForm)
        {
            if (id != freeForm.ff_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freeForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreeFormExists(freeForm.ff_Id))
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
            return View(freeForm);
        }

        // GET: FreeForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freeForm = await _context.FreeForm
                .FirstOrDefaultAsync(m => m.ff_Id == id);
            if (freeForm == null)
            {
                return NotFound();
            }

            return View(freeForm);
        }

        // POST: FreeForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var freeForm = await _context.FreeForm.FindAsync(id);
            _context.FreeForm.Remove(freeForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FreeFormExists(int id)
        {
            return _context.FreeForm.Any(e => e.ff_Id == id);
        }
    }
}
