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
    public class AttendanceM2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceM2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AttendanceM2
        public async Task<IActionResult> Index()
        {
            return View(await _context.AttendanceM2.ToListAsync());
        }

        // GET: AttendanceM2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceM2 = await _context.AttendanceM2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendanceM2 == null)
            {
                return NotFound();
            }

            return View(attendanceM2);
        }

        // GET: AttendanceM2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AttendanceM2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Arrv_Time,Leav_Time,date,User_Id")] AttendanceM2 attendanceM2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendanceM2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendanceM2);
        }

        // GET: AttendanceM2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceM2 = await _context.AttendanceM2.FindAsync(id);
            if (attendanceM2 == null)
            {
                return NotFound();
            }
            return View(attendanceM2);
        }

        // POST: AttendanceM2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Arrv_Time,Leav_Time,date,User_Id")] AttendanceM2 attendanceM2)
        {
            if (id != attendanceM2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendanceM2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceM2Exists(attendanceM2.Id))
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
            return View(attendanceM2);
        }

        // GET: AttendanceM2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceM2 = await _context.AttendanceM2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendanceM2 == null)
            {
                return NotFound();
            }

            return View(attendanceM2);
        }

        // POST: AttendanceM2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendanceM2 = await _context.AttendanceM2.FindAsync(id);
            _context.AttendanceM2.Remove(attendanceM2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceM2Exists(int id)
        {
            return _context.AttendanceM2.Any(e => e.Id == id);
        }
    }
}
