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
    public class AttendanceHKsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceHKsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AttendanceHKs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AttendanceHK.ToListAsync());
        }

        // GET: AttendanceHKs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceHK = await _context.AttendanceHK
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendanceHK == null)
            {
                return NotFound();
            }

            return View(attendanceHK);
        }

        // GET: AttendanceHKs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AttendanceHKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Hour_1,Hour_2,date,User_Id")] AttendanceHK attendanceHK)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendanceHK);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendanceHK);
        }

        // GET: AttendanceHKs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceHK = await _context.AttendanceHK.FindAsync(id);
            if (attendanceHK == null)
            {
                return NotFound();
            }
            return View(attendanceHK);
        }

        // POST: AttendanceHKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Hour_1,Hour_2,date,User_Id")] AttendanceHK attendanceHK)
        {
            if (id != attendanceHK.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendanceHK);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceHKExists(attendanceHK.Id))
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
            return View(attendanceHK);
        }

        // GET: AttendanceHKs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceHK = await _context.AttendanceHK
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendanceHK == null)
            {
                return NotFound();
            }

            return View(attendanceHK);
        }

        // POST: AttendanceHKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendanceHK = await _context.AttendanceHK.FindAsync(id);
            _context.AttendanceHK.Remove(attendanceHK);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceHKExists(int id)
        {
            return _context.AttendanceHK.Any(e => e.Id == id);
        }
    }
}
