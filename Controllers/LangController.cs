using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Controllers
{
    public class LangController : Controller
    {
        private readonly AppDbContext _context;

        public LangController(AppDbContext context)
        {
            _context = context;
        }

        // Tüm verileri listele
        public async Task<IActionResult> Index()
        {
            var lang = await _context.Lang.ToListAsync();
            return View("~/Views/Shared/AdminPages/Lang.cshtml", lang);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAll([FromBody] Lang updated)
        {
            if (updated == null)
            {
                return Json(new { success = false, message = "Veri boş." });
            }

            var lang = await _context.Lang.FirstOrDefaultAsync(a => a.LangId == updated.LangId);
            if (lang == null)
            {
                return Json(new { success = false, message = "Kayıt bulunamadı." });
            }

            lang.LangName = updated.LangName;

            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Lang newlang)
        {
            if (string.IsNullOrWhiteSpace(newlang.LangName))
            {
                return Json(new { success = false, message = "Yetenek boş olamaz." });
            }

            try
            {
                _context.Lang.Add(newlang);
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
                var lang = _context.Lang.Find(id);
                if (lang == null)
                {
                    return Json(new { success = false, message = "Kayıt bulunamadı." });
                }

                _context.Lang.Remove(lang);
                _context.SaveChanges();
                return Json(new { success = true });
            }


    }
}
