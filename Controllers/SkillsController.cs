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

        // Tek veri döndürdüğümüz için listelemeye gerek yok
        public async Task<IActionResult> Index()
        {
            var skills = await _context.Skills.FirstOrDefaultAsync();
            return View(skills);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAll([FromBody] Skills updated)
        {
            if (updated == null)
            {
                return Json(new { success = false, message = "Veri boş." });
            }

            var skills = await _context.Skills.FirstOrDefaultAsync(s => s.SkillsId == updated.SkillsId);
            if (skills == null)
            {
                return Json(new { success = false, message = "Kayıt bulunamadı." });
            }

            skills.SkillName = updated.SkillName;
            skills.SkillName2 = updated.SkillName2;
            skills.SkillName3 = updated.SkillName3;
            skills.SkillName4 = updated.SkillName4;
            skills.SkillName5 = updated.SkillName5;
            skills.SkillName6 = updated.SkillName6;

            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
