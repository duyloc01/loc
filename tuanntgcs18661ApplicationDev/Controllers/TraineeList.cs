using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tuanntgcs18661ApplicationDev.Data;
using tuanntgcs18661ApplicationDev.Models;

namespace tuanntgcs18661ApplicationDev.Controllers
{
    //[Authorize(Roles = "Admin, Staff")]
    public class TraineeListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TraineeListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: 
        public async Task<IActionResult> Index()
        {
            var traineeIds = await _context.UserRoles.Where(u => u.RoleId == "Trainee").Select(u => u.UserId).ToListAsync();
            return View(await _context.Users.Where(u => traineeIds.Contains(u.Id)).ToListAsync());
        }
        //[Authorize(Roles = "Admin")]
        // GET: /Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(u => u.Department).FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: /Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["DepartmentIds"] = new SelectList(_context.Departments, "Id", "Name", user.DepartmentId);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, CUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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

            ViewData["DepartmentIds"] = new SelectList(_context.Departments, "Id", "Name", user.DepartmentId);
            return View(user);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.FindAsync(id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
