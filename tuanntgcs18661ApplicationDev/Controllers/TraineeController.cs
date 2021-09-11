using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tuanntgcs18661ApplicationDev.Data;
using tuanntgcs18661ApplicationDev.Models;

namespace tuanntgcs18661ApplicationDev.Controllers
{
    //[Authorize(Roles ="Trainee")]
    public class TraineeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TraineeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Classrooms
        public async Task<IActionResult> Index()        
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var classroomIds = await _context.TraineeClassrooms.Where(t => t.TraineeId == userId).Select(t => t.ClassroomId).ToListAsync();
            var classrooms = await _context.Classrooms.Where(c => classroomIds.Contains(c.Id)).Include(c => c.ClassProfile).Include(c => c.Course).Include(c => c.Course.Category).ToListAsync();
            return View(classrooms);
        }

        // GET: Classrooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = await _context.Classrooms
                .Include(c => c.ClassProfile)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classroom == null)
            {
                return NotFound();
            }
            ViewData["Topics"] = await _context.Topics.Include(t => t.Trainer).Where(t => t.ClassroomId == id).ToListAsync();
            return View(classroom);
        }
    }
}
