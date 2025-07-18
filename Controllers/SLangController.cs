using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;

namespace myblog.Controllers
{
    public class SLangController : Controller
    {
        private readonly AppDbContext _context;

        public SLangController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.SLang.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(SLang slang)
        {
            if (ModelState.IsValid)
            {
                _context.SLang.Add(slang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slang);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.SLang.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SLang slang)
        {
            _context.SLang.Update(slang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.SLang.FindAsync(id);
            if (item == null) return NotFound();

            _context.SLang.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ✅ AJAX üzerinden güncelleme için eklenen metod
        [HttpPost]
        [Route("SLang/UpdatesSlang")] // Bu route'a JS'ten fetch yapıyorsun
        public async Task<IActionResult> UpdateSlang([FromBody] UpdateRequest request)
        {
            if (request == null || request.Id == 0 || string.IsNullOrWhiteSpace(request.PropertyName))
            {
                return Json(new { success = false, message = "Geçersiz veri gönderildi." });
            }

            var Slang = await _context.SLang.FindAsync(request.Id);
            if (Slang == null)
            {
                return NotFound(new { success = false, message = "Skill bulunamadı." });
            }

            switch (request.PropertyName.Trim().ToLower())
            {
                case "slangname":
                    Slang.SlangName = request.NewValue;
                    break;
                case "slanglevel":
                    Slang.SlangLevel = request.NewValue;
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
