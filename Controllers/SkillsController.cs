using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Controllers
{
    public class SkillsController : Controller
    {
        private readonly AppDbContext _context;

        public SkillsController(AppDbContext context)
        {
            _context = context;
        }

        // Tüm verileri listele
        public async Task<IActionResult> Index()
        {
            var skills = await _context.Skills.ToListAsync();
            return View(skills);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAll([FromBody] Skills updated)
        {
            if (updated == null)
            {
                return Json(new { success = false, message = "Veri boş." });
            }

            var skill = await _context.Skills.FirstOrDefaultAsync(s => s.SkillsId == updated.SkillsId);
            if (skill == null)
            {
                return Json(new { success = false, message = "Kayıt bulunamadı." });
            }

            skill.SkillName = updated.SkillName;

            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Skills newSkill)
        {
            if (string.IsNullOrWhiteSpace(newSkill.SkillName))
            {
                return Json(new { success = false, message = "Yetenek boş olamaz." });
            }

            try
            {
                _context.Skills.Add(newSkill);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var skills = _context.Skills.Find(id);
            if (skills == null)
            {
                return Json(new { success = false, message = "Kayıt bulunamadı." });
            }

            _context.Skills.Remove(skills);
            _context.SaveChanges();
            return Json(new { success = true });
        }
    }
}
