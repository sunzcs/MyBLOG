using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;
using System.Threading.Tasks;
using System.Linq;

namespace myblog.Controllers
{
    public class TextController : Controller
    {
        private readonly AppDbContext _context;

        public TextController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Text (Listeleme sayfası - istersen kullan)
        public async Task<IActionResult> Index()
        {
            var texts = await _context.Text.ToListAsync();
            return View(texts);
        }

        // GET: Text/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var text = await _context.Text.FirstOrDefaultAsync(t => t.TextId == id);
            if (text == null) return NotFound();

            return View(text);
        }

        // GET: Text/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Text/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Text text)
        {
            if (ModelState.IsValid)
            {
                _context.Add(text);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(text);
        }

        // GET: Text/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var text = await _context.Text.FindAsync(id);
            if (text == null) return NotFound();

            return View(text);
        }

        // POST: Text/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Text text)
        {
            if (id != text.TextId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(text);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TextExists(text.TextId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(text);
        }

        // GET: Text/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var text = await _context.Text.FirstOrDefaultAsync(t => t.TextId == id);
            if (text == null) return NotFound();

            return View(text);
        }

        // POST: Text/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var text = await _context.Text.FindAsync(id);
            if (text != null)
            {
                _context.Text.Remove(text);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // ✅ AJAX güncelleme metodu
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateText([FromBody] UpdateRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.NewValue))
                return Json(new { success = false, message = "Geçersiz veri." });

            var text = await _context.Text.FindAsync(request.Id);
            if (text == null)
                return Json(new { success = false, message = "Kayıt bulunamadı." });

            text.Text1 = request.NewValue;

            try
            {
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        private bool TextExists(int id)
        {
            return _context.Text.Any(e => e.TextId == id);
        }
    }
}
