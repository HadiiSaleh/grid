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
    public class MeetingRRsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingRRsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeetingRRs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MeetingRR.Include(m => m.user);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MeetingRRs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRR = await _context.MeetingRR
                .Include(m => m.user)
                .FirstOrDefaultAsync(m => m.mrrId == id);
            if (meetingRR == null)
            {
                return NotFound();
            }

            return View(meetingRR);
        }

        // GET: MeetingRRs/Create
        public IActionResult Create()
        {
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: MeetingRRs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mrrId,hour,date,objective,summary,id")] MeetingRR meetingRR)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingRR);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", meetingRR.id);
            return View(meetingRR);
        }

        // GET: MeetingRRs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRR = await _context.MeetingRR.FindAsync(id);
            if (meetingRR == null)
            {
                return NotFound();
            }
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", meetingRR.id);
            return View(meetingRR);
        }

        // POST: MeetingRRs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mrrId,hour,date,objective,summary,id")] MeetingRR meetingRR)
        {
            if (id != meetingRR.mrrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingRR);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingRRExists(meetingRR.mrrId))
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
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", meetingRR.id);
            return View(meetingRR);
        }

        // GET: MeetingRRs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingRR = await _context.MeetingRR
                .Include(m => m.user)
                .FirstOrDefaultAsync(m => m.mrrId == id);
            if (meetingRR == null)
            {
                return NotFound();
            }

            return View(meetingRR);
        }

        // POST: MeetingRRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingRR = await _context.MeetingRR.FindAsync(id);
            _context.MeetingRR.Remove(meetingRR);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingRRExists(int id)
        {
            return _context.MeetingRR.Any(e => e.mrrId == id);
        }
    }
}
