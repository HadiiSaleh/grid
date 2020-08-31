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
    public class User_OpeningClosingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public User_OpeningClosingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User_OpeningClosing
        public async Task<IActionResult> Index()
        {
            return View(await _context.User_OpeningClosing.ToListAsync());
        }

        // GET: User_OpeningClosing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_OpeningClosing = await _context.User_OpeningClosing
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user_OpeningClosing == null)
            {
                return NotFound();
            }

            return View(user_OpeningClosing);
        }

        // GET: User_OpeningClosing/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User_OpeningClosing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,project_id,openingclosing_id")] User_OpeningClosing user_OpeningClosing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_OpeningClosing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user_OpeningClosing);
        }

        // GET: User_OpeningClosing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_OpeningClosing = await _context.User_OpeningClosing.FindAsync(id);
            if (user_OpeningClosing == null)
            {
                return NotFound();
            }
            return View(user_OpeningClosing);
        }

        // POST: User_OpeningClosing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,project_id,openingclosing_id")] User_OpeningClosing user_OpeningClosing)
        {
            if (id != user_OpeningClosing.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_OpeningClosing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_OpeningClosingExists(user_OpeningClosing.ID))
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
            return View(user_OpeningClosing);
        }

        // GET: User_OpeningClosing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_OpeningClosing = await _context.User_OpeningClosing
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user_OpeningClosing == null)
            {
                return NotFound();
            }

            return View(user_OpeningClosing);
        }

        // POST: User_OpeningClosing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_OpeningClosing = await _context.User_OpeningClosing.FindAsync(id);
            _context.User_OpeningClosing.Remove(user_OpeningClosing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_OpeningClosingExists(int id)
        {
            return _context.User_OpeningClosing.Any(e => e.ID == id);
        }
    }
}
