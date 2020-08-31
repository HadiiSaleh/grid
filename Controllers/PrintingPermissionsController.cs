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
    public class PrintingPermissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrintingPermissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrintingPermissions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PrintingPermission.Include(p => p.user);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PrintingPermissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printingPermission = await _context.PrintingPermission
                .Include(p => p.user)
                .FirstOrDefaultAsync(m => m.printing_id == id);
            if (printingPermission == null)
            {
                return NotFound();
            }

            return View(printingPermission);
        }

        // GET: PrintingPermissions/Create
        public IActionResult Create()
        {
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: PrintingPermissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("printing_id,page_number,coloredOrNot,id")] PrintingPermission printingPermission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(printingPermission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", printingPermission.id);
            return View(printingPermission);
        }

        // GET: PrintingPermissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printingPermission = await _context.PrintingPermission.FindAsync(id);
            if (printingPermission == null)
            {
                return NotFound();
            }
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", printingPermission.id);
            return View(printingPermission);
        }

        // POST: PrintingPermissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("printing_id,page_number,coloredOrNot,id")] PrintingPermission printingPermission)
        {
            if (id != printingPermission.printing_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(printingPermission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrintingPermissionExists(printingPermission.printing_id))
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
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", printingPermission.id);
            return View(printingPermission);
        }

        // GET: PrintingPermissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printingPermission = await _context.PrintingPermission
                .Include(p => p.user)
                .FirstOrDefaultAsync(m => m.printing_id == id);
            if (printingPermission == null)
            {
                return NotFound();
            }

            return View(printingPermission);
        }

        // POST: PrintingPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var printingPermission = await _context.PrintingPermission.FindAsync(id);
            _context.PrintingPermission.Remove(printingPermission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrintingPermissionExists(int id)
        {
            return _context.PrintingPermission.Any(e => e.printing_id == id);
        }
    }
}
