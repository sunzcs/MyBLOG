using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;

namespace myblog.Controllers
{
    public class EducationsController : Controller
    {
        private readonly AppDbContext _context;

        public EducationsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Education.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Education.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(education);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Education.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Education education)
        {
            _context.Education.Update(education);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Education.FindAsync(id);
            if (item == null) return NotFound();

            _context.Education.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost]
        public IActionResult UpdateAll([FromBody] Education updated)
        {
            if (updated==null)
            {
                return Json(new { success = false, message = "boş veri." });
            }
            var education = _context.Education.FirstOrDefault(x => x.EducationId == updated.EducationId);
            if (education == null) return Json(new { success = false, message = "Kullanıcı bulunamadı." });

            education.SCName = updated.SCName;
            education.SCStatement = updated.SCStatement;
            education.SCStartdate = updated.SCStartdate;
            education.SCFinishdate = updated.SCFinishdate;

            _context.SaveChanges();

            return Json(new { success = true });
        }
        
    }
}
