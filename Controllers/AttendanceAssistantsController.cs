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
    public class AttendanceAssistantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceAssistantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AttendanceAssistants
        public async Task<IActionResult> Index()
        {
            return View(await _context.AttendanceAssistant.ToListAsync());
        }

        // GET: AttendanceAssistants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceAssistant = await _context.AttendanceAssistant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendanceAssistant == null)
            {
                return NotFound();
            }

            return View(attendanceAssistant);
        }

        // GET: AttendanceAssistants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AttendanceAssistants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Arrival_Time,Leaving_Time,date,User_Id")] AttendanceAssistant attendanceAssistant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendanceAssistant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendanceAssistant);
        }

        // GET: AttendanceAssistants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceAssistant = await _context.AttendanceAssistant.FindAsync(id);
            if (attendanceAssistant == null)
            {
                return NotFound();
            }
            return View(attendanceAssistant);
        }

        // POST: AttendanceAssistants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Arrival_Time,Leaving_Time,date,User_Id")] AttendanceAssistant attendanceAssistant)
        {
            if (id != attendanceAssistant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendanceAssistant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceAssistantExists(attendanceAssistant.Id))
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
            return View(attendanceAssistant);
        }

        // GET: AttendanceAssistants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceAssistant = await _context.AttendanceAssistant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendanceAssistant == null)
            {
                return NotFound();
            }

            return View(attendanceAssistant);
        }

        // POST: AttendanceAssistants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendanceAssistant = await _context.AttendanceAssistant.FindAsync(id);
            _context.AttendanceAssistant.Remove(attendanceAssistant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceAssistantExists(int id)
        {
            return _context.AttendanceAssistant.Any(e => e.Id == id);
        }
    }
}
