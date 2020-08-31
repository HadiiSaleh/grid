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
    public class AttendancePHDStsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendancePHDStsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AttendancePHDSts
        public async Task<IActionResult> Index()
        {
            return View(await _context.AttendancePHDSt.ToListAsync());
        }

        // GET: AttendancePHDSts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendancePHDSt = await _context.AttendancePHDSt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendancePHDSt == null)
            {
                return NotFound();
            }

            return View(attendancePHDSt);
        }

        // GET: AttendancePHDSts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AttendancePHDSts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Arrv_Time,Leav_Time,date,User_Id")] AttendancePHDSt attendancePHDSt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendancePHDSt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendancePHDSt);
        }

        // GET: AttendancePHDSts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendancePHDSt = await _context.AttendancePHDSt.FindAsync(id);
            if (attendancePHDSt == null)
            {
                return NotFound();
            }
            return View(attendancePHDSt);
        }

        // POST: AttendancePHDSts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Arrv_Time,Leav_Time,date,User_Id")] AttendancePHDSt attendancePHDSt)
        {
            if (id != attendancePHDSt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendancePHDSt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendancePHDStExists(attendancePHDSt.Id))
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
            return View(attendancePHDSt);
        }

        // GET: AttendancePHDSts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendancePHDSt = await _context.AttendancePHDSt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendancePHDSt == null)
            {
                return NotFound();
            }

            return View(attendancePHDSt);
        }

        // POST: AttendancePHDSts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendancePHDSt = await _context.AttendancePHDSt.FindAsync(id);
            _context.AttendancePHDSt.Remove(attendancePHDSt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendancePHDStExists(int id)
        {
            return _context.AttendancePHDSt.Any(e => e.Id == id);
        }
    }
}
