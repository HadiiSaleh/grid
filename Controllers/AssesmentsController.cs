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
    public class AssesmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssesmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assesments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assesment.ToListAsync());
        }

        // GET: Assesments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assesment = await _context.Assesment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assesment == null)
            {
                return NotFound();
            }

            return View(assesment);
        }

        // GET: Assesments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assesments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TraineeName,StudentName,quality,quantity,work_habits,communication,attitude,professionalism,leadership,User_Id")] Assesment assesment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assesment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assesment);
        }

        // GET: Assesments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assesment = await _context.Assesment.FindAsync(id);
            if (assesment == null)
            {
                return NotFound();
            }
            return View(assesment);
        }

        // POST: Assesments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TraineeName,StudentName,quality,quantity,work_habits,communication,attitude,professionalism,leadership,User_Id")] Assesment assesment)
        {
            if (id != assesment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assesment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssesmentExists(assesment.Id))
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
            return View(assesment);
        }

        // GET: Assesments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assesment = await _context.Assesment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assesment == null)
            {
                return NotFound();
            }

            return View(assesment);
        }

        // POST: Assesments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assesment = await _context.Assesment.FindAsync(id);
            _context.Assesment.Remove(assesment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssesmentExists(int id)
        {
            return _context.Assesment.Any(e => e.Id == id);
        }
    }
}
