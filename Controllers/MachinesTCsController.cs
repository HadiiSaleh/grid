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
    public class MachinesTCsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MachinesTCsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MachinesTCs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MachinesTC.ToListAsync());
        }

        // GET: MachinesTCs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinesTC = await _context.MachinesTC
                .FirstOrDefaultAsync(m => m.mtcId == id);
            if (machinesTC == null)
            {
                return NotFound();
            }

            return View(machinesTC);
        }

        // GET: MachinesTCs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MachinesTCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mtcId,name")] MachinesTC machinesTC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machinesTC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(machinesTC);
        }

        // GET: MachinesTCs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinesTC = await _context.MachinesTC.FindAsync(id);
            if (machinesTC == null)
            {
                return NotFound();
            }
            return View(machinesTC);
        }

        // POST: MachinesTCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mtcId,name")] MachinesTC machinesTC)
        {
            if (id != machinesTC.mtcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machinesTC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachinesTCExists(machinesTC.mtcId))
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
            return View(machinesTC);
        }

        // GET: MachinesTCs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinesTC = await _context.MachinesTC
                .FirstOrDefaultAsync(m => m.mtcId == id);
            if (machinesTC == null)
            {
                return NotFound();
            }

            return View(machinesTC);
        }

        // POST: MachinesTCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machinesTC = await _context.MachinesTC.FindAsync(id);
            _context.MachinesTC.Remove(machinesTC);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachinesTCExists(int id)
        {
            return _context.MachinesTC.Any(e => e.mtcId == id);
        }
    }
}
