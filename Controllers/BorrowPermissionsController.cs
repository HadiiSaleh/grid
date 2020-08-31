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
    public class BorrowPermissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowPermissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BorrowPermissions
        public async Task<IActionResult> Index()
        {
            return View(await _context.BorrowPermission.ToListAsync());
        }

        // GET: BorrowPermissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowPermission = await _context.BorrowPermission
                .FirstOrDefaultAsync(m => m.ID == id);
            if (borrowPermission == null)
            {
                return NotFound();
            }

            return View(borrowPermission);
        }

        // GET: BorrowPermissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BorrowPermissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,User_Id,Pos,Pro_name,Borr_Object,quantity,Return_Date")] BorrowPermission borrowPermission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowPermission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(borrowPermission);
        }

        // GET: BorrowPermissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowPermission = await _context.BorrowPermission.FindAsync(id);
            if (borrowPermission == null)
            {
                return NotFound();
            }
            return View(borrowPermission);
        }

        // POST: BorrowPermissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,User_Id,Pos,Pro_name,Borr_Object,quantity,Return_Date")] BorrowPermission borrowPermission)
        {
            if (id != borrowPermission.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowPermission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowPermissionExists(borrowPermission.ID))
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
            return View(borrowPermission);
        }

        // GET: BorrowPermissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowPermission = await _context.BorrowPermission
                .FirstOrDefaultAsync(m => m.ID == id);
            if (borrowPermission == null)
            {
                return NotFound();
            }

            return View(borrowPermission);
        }

        // POST: BorrowPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrowPermission = await _context.BorrowPermission.FindAsync(id);
            _context.BorrowPermission.Remove(borrowPermission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowPermissionExists(int id)
        {
            return _context.BorrowPermission.Any(e => e.ID == id);
        }
    }
}
