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
    public class TrainingPreRegistrationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingPreRegistrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrainingPreRegistrations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TrainingPreRegistration.Include(t => t.user);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TrainingPreRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingPreRegistration = await _context.TrainingPreRegistration
                .Include(t => t.user)
                .FirstOrDefaultAsync(m => m.tpr_id == id);
            if (trainingPreRegistration == null)
            {
                return NotFound();
            }

            return View(trainingPreRegistration);
        }

        // GET: TrainingPreRegistrations/Create
        public IActionResult Create()
        {
            ViewData["user_id"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: TrainingPreRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tpr_id,user_id,name,speciality,year,email,phone_number,duration")] TrainingPreRegistration trainingPreRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingPreRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["user_id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", trainingPreRegistration.user_id);
            return View(trainingPreRegistration);
        }

        // GET: TrainingPreRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingPreRegistration = await _context.TrainingPreRegistration.FindAsync(id);
            if (trainingPreRegistration == null)
            {
                return NotFound();
            }
            ViewData["user_id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", trainingPreRegistration.user_id);
            return View(trainingPreRegistration);
        }

        // POST: TrainingPreRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tpr_id,user_id,name,speciality,year,email,phone_number,duration")] TrainingPreRegistration trainingPreRegistration)
        {
            if (id != trainingPreRegistration.tpr_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingPreRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingPreRegistrationExists(trainingPreRegistration.tpr_id))
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
            ViewData["user_id"] = new SelectList(_context.Set<User>(), "UserId", "UserId", trainingPreRegistration.user_id);
            return View(trainingPreRegistration);
        }

        // GET: TrainingPreRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingPreRegistration = await _context.TrainingPreRegistration
                .Include(t => t.user)
                .FirstOrDefaultAsync(m => m.tpr_id == id);
            if (trainingPreRegistration == null)
            {
                return NotFound();
            }

            return View(trainingPreRegistration);
        }

        // POST: TrainingPreRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingPreRegistration = await _context.TrainingPreRegistration.FindAsync(id);
            _context.TrainingPreRegistration.Remove(trainingPreRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingPreRegistrationExists(int id)
        {
            return _context.TrainingPreRegistration.Any(e => e.tpr_id == id);
        }
    }
}
