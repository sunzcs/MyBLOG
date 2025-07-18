using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;

namespace myblog.Controllers
{
    public class LangController : Controller
    {
        private readonly AppDbContext _context;
        public LangController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.Lang.ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Lang lang)
        {
            if (!ModelState.IsValid) return View(lang);
            _context.Lang.Add(lang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Lang.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Lang lang)
        {
            _context.Lang.Update(lang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Lang.FindAsync(id);
            if (item == null) return NotFound();
            _context.Lang.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ✅ AJAX ile güncelleme (UpdateRequest ile)
        [HttpPost]
        [Route("Lang/UpdateLang")] 
        public async Task<IActionResult> UpdateLang([FromBody] UpdateRequest request)
        {
            if (request == null || request.Id == 0 || string.IsNullOrWhiteSpace(request.PropertyName))
            {
                return Json(new { success = false, message = "Geçersiz veri gönderildi." });
            }

            var Lang = await _context.Lang.FindAsync(request.Id);
            if (Lang == null)
            {
                return NotFound(new { success = false, message = "Lang bulunamadı." });
            }

            switch (request.PropertyName.Trim().ToLower())
            {
                case "LangName":
                    Lang.LangName = request.NewValue;
                    break;
                case "Langlevel":
                    Lang.LangLevel = request.NewValue;
                    break;
                default:
                    return Json(new { success = false, message = $"'{request.PropertyName}' alanı desteklenmiyor." });
            }

            try
            {
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Hata: " + ex.Message });
            }
        }
    }
}
