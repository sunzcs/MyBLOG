using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;

namespace myblog.Controllers
{
    public class SkillsController : Controller
    {
        private readonly AppDbContext _context;

        public SkillsController(AppDbContext context)
        {
            _context = context;
        }

        // Sayfa: Listeleme
        public async Task<IActionResult> Index()
        {
            var skills = await _context.Skills.ToListAsync();
            return View(skills);
        }

        // Sayfa: Yeni beceri oluşturma formu
        public IActionResult Create()
        {
            return View();
        }

        // Sayfa: Yeni beceriyi kaydet
        [HttpPost]
        public async Task<IActionResult> Create(Skills skills)
        {
            if (!ModelState.IsValid)
                return View(skills);

            _context.Skills.Add(skills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Sayfa: Düzenleme formu
        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
                return NotFound();

            return View(skill);
        }

        // Sayfa: Düzenleme formu POST
        [HttpPost]
        public async Task<IActionResult> Edit(Skills skills)
        {
            if (!ModelState.IsValid)
                return View(skills);

            _context.Skills.Update(skills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Sayfa: Silme
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
                return NotFound();

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost]
        [Route("Skills/UpdateSkills")] 
        public async Task<IActionResult> UpdateSkills([FromBody] UpdateRequest request)
        {
            if (request == null || request.Id == 0 || string.IsNullOrWhiteSpace(request.PropertyName))
            {
                return BadRequest(new { success = false, message = "Geçersiz veri gönderildi." });
            }

            var skills = await _context.Skills.FindAsync(request.Id);
            if (skills == null)
            {
                return NotFound(new { success = false, message = "Skill bulunamadı." });
            }

            // Güncellenecek alan
            switch (request.PropertyName.Trim().ToLower())
            {
                case "skillname":
                    skills.SkillName = request.NewValue;
                    break;
                default:
                    return BadRequest(new { success = false, message = $"'{request.PropertyName}' alanı desteklenmiyor." });
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Veri güncellenirken hata: " + ex.Message });
            }
        }
    }
}
