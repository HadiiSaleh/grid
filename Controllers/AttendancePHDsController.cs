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
    public class AttendancePHDsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendancePHDsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AttendancePHDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AttendancePHD.ToListAsync());
        }

        // GET: AttendancePHDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendancePHD = await _context.AttendancePHD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendancePHD == null)
            {
                return NotFound();
            }

            return View(attendancePHD);
        }

        // GET: AttendancePHDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AttendancePHDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Arrv_Time,Leav_Time,date,User_Id")] AttendancePHD attendancePHD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendancePHD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendancePHD);
        }

        // GET: AttendancePHDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendancePHD = await _context.AttendancePHD.FindAsync(id);
            if (attendancePHD == null)
            {
                return NotFound();
            }
            return View(attendancePHD);
        }

        // POST: AttendancePHDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Arrv_Time,Leav_Time,date,User_Id")] AttendancePHD attendancePHD)
        {
            if (id != attendancePHD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendancePHD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendancePHDExists(attendancePHD.Id))
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
            return View(attendancePHD);
        }

        // GET: AttendancePHDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendancePHD = await _context.AttendancePHD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendancePHD == null)
            {
                return NotFound();
            }

            return View(attendancePHD);
        }

        // POST: AttendancePHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendancePHD = await _context.AttendancePHD.FindAsync(id);
            _context.AttendancePHD.Remove(attendancePHD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendancePHDExists(int id)
        {
            return _context.AttendancePHD.Any(e => e.Id == id);
        }
    }
}
