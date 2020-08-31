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
    public class InternshipRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InternshipRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InternshipRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InternshipRequest.Include(i => i.user);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InternshipRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internshipRequest = await _context.InternshipRequest
                .Include(i => i.user)
                .FirstOrDefaultAsync(m => m.intr_id == id);
            if (internshipRequest == null)
            {
                return NotFound();
            }

            return View(internshipRequest);
        }

        // GET: InternshipRequests/Create
        public IActionResult Create()
        {
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: InternshipRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("intr_id,student_id,phone_number,email,photo,place,fundingDuration,signature,id")] InternshipRequest internshipRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(internshipRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", internshipRequest.id);
            return View(internshipRequest);
        }

        // GET: InternshipRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internshipRequest = await _context.InternshipRequest.FindAsync(id);
            if (internshipRequest == null)
            {
                return NotFound();
            }
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", internshipRequest.id);
            return View(internshipRequest);
        }

        // POST: InternshipRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("intr_id,student_id,phone_number,email,photo,place,fundingDuration,signature,id")] InternshipRequest internshipRequest)
        {
            if (id != internshipRequest.intr_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(internshipRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InternshipRequestExists(internshipRequest.intr_id))
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
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", internshipRequest.id);
            return View(internshipRequest);
        }

        // GET: InternshipRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internshipRequest = await _context.InternshipRequest
                .Include(i => i.user)
                .FirstOrDefaultAsync(m => m.intr_id == id);
            if (internshipRequest == null)
            {
                return NotFound();
            }

            return View(internshipRequest);
        }

        // POST: InternshipRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var internshipRequest = await _context.InternshipRequest.FindAsync(id);
            _context.InternshipRequest.Remove(internshipRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InternshipRequestExists(int id)
        {
            return _context.InternshipRequest.Any(e => e.intr_id == id);
        }
    }
}
