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
    public class MeetingPresencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingPresencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeetingPresences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MeetingPresence.Include(m => m.meetingRR);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MeetingPresences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingPresence = await _context.MeetingPresence
                .Include(m => m.meetingRR)
                .FirstOrDefaultAsync(m => m.mpre_id == id);
            if (meetingPresence == null)
            {
                return NotFound();
            }

            return View(meetingPresence);
        }

        // GET: MeetingPresences/Create
        public IActionResult Create()
        {
            ViewData["mrrId"] = new SelectList(_context.Set<MeetingRR>(), "mrrId", "hour");
            return View();
        }

        // POST: MeetingPresences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mpre_id,name,mrrId")] MeetingPresence meetingPresence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingPresence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["mrrId"] = new SelectList(_context.Set<MeetingRR>(), "mrrId", "hour", meetingPresence.mrrId);
            return View(meetingPresence);
        }

        // GET: MeetingPresences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingPresence = await _context.MeetingPresence.FindAsync(id);
            if (meetingPresence == null)
            {
                return NotFound();
            }
            ViewData["mrrId"] = new SelectList(_context.Set<MeetingRR>(), "mrrId", "hour", meetingPresence.mrrId);
            return View(meetingPresence);
        }

        // POST: MeetingPresences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mpre_id,name,mrrId")] MeetingPresence meetingPresence)
        {
            if (id != meetingPresence.mpre_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingPresence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingPresenceExists(meetingPresence.mpre_id))
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
            ViewData["mrrId"] = new SelectList(_context.Set<MeetingRR>(), "mrrId", "hour", meetingPresence.mrrId);
            return View(meetingPresence);
        }

        // GET: MeetingPresences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingPresence = await _context.MeetingPresence
                .Include(m => m.meetingRR)
                .FirstOrDefaultAsync(m => m.mpre_id == id);
            if (meetingPresence == null)
            {
                return NotFound();
            }

            return View(meetingPresence);
        }

        // POST: MeetingPresences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingPresence = await _context.MeetingPresence.FindAsync(id);
            _context.MeetingPresence.Remove(meetingPresence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingPresenceExists(int id)
        {
            return _context.MeetingPresence.Any(e => e.mpre_id == id);
        }
    }
}
