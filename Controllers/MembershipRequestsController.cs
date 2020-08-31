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
    public class MembershipRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembershipRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MembershipRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MembershipRequest.Include(m => m.user);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MembershipRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membershipRequest = await _context.MembershipRequest
                .Include(m => m.user)
                .FirstOrDefaultAsync(m => m.mr_id == id);
            if (membershipRequest == null)
            {
                return NotFound();
            }

            return View(membershipRequest);
        }

        // GET: MembershipRequests/Create
        public IActionResult Create()
        {
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: MembershipRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mr_id,signature,id")] MembershipRequest membershipRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membershipRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", membershipRequest.id);
            return View(membershipRequest);
        }

        // GET: MembershipRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membershipRequest = await _context.MembershipRequest.FindAsync(id);
            if (membershipRequest == null)
            {
                return NotFound();
            }
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", membershipRequest.id);
            return View(membershipRequest);
        }

        // POST: MembershipRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mr_id,signature,id")] MembershipRequest membershipRequest)
        {
            if (id != membershipRequest.mr_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membershipRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipRequestExists(membershipRequest.mr_id))
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
            ViewData["id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", membershipRequest.id);
            return View(membershipRequest);
        }

        // GET: MembershipRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membershipRequest = await _context.MembershipRequest
                .Include(m => m.user)
                .FirstOrDefaultAsync(m => m.mr_id == id);
            if (membershipRequest == null)
            {
                return NotFound();
            }

            return View(membershipRequest);
        }

        // POST: MembershipRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membershipRequest = await _context.MembershipRequest.FindAsync(id);
            _context.MembershipRequest.Remove(membershipRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershipRequestExists(int id)
        {
            return _context.MembershipRequest.Any(e => e.mr_id == id);
        }
    }
}
