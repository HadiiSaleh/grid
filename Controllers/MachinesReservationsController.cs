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
    public class MachinesReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MachinesReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MachinesReservations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MachinesReservation.Include(m => m.Experiment);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MachinesReservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinesReservation = await _context.MachinesReservation
                .Include(m => m.Experiment)
                .FirstOrDefaultAsync(m => m.machResId == id);
            if (machinesReservation == null)
            {
                return NotFound();
            }

            return View(machinesReservation);
        }

        // GET: MachinesReservations/Create
        public IActionResult Create()
        {
            ViewData["ex_id"] = new SelectList(_context.Experiment, "Exp_Id", "Exp_Id");
            return View();
        }

        // POST: MachinesReservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("machResId,machine_name,date,ResOrNot,ex_id")] MachinesReservation machinesReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machinesReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ex_id"] = new SelectList(_context.Experiment, "Exp_Id", "Exp_Id", machinesReservation.ex_id);
            return View(machinesReservation);
        }

        // GET: MachinesReservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinesReservation = await _context.MachinesReservation.FindAsync(id);
            if (machinesReservation == null)
            {
                return NotFound();
            }
            ViewData["ex_id"] = new SelectList(_context.Experiment, "Exp_Id", "Exp_Id", machinesReservation.ex_id);
            return View(machinesReservation);
        }

        // POST: MachinesReservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("machResId,machine_name,date,ResOrNot,ex_id")] MachinesReservation machinesReservation)
        {
            if (id != machinesReservation.machResId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machinesReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachinesReservationExists(machinesReservation.machResId))
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
            ViewData["ex_id"] = new SelectList(_context.Experiment, "Exp_Id", "Exp_Id", machinesReservation.ex_id);
            return View(machinesReservation);
        }

        // GET: MachinesReservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinesReservation = await _context.MachinesReservation
                .Include(m => m.Experiment)
                .FirstOrDefaultAsync(m => m.machResId == id);
            if (machinesReservation == null)
            {
                return NotFound();
            }

            return View(machinesReservation);
        }

        // POST: MachinesReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machinesReservation = await _context.MachinesReservation.FindAsync(id);
            _context.MachinesReservation.Remove(machinesReservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachinesReservationExists(int id)
        {
            return _context.MachinesReservation.Any(e => e.machResId == id);
        }
    }
}
