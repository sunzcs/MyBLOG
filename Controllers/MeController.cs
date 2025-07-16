using Microsoft.AspNetCore.Mvc;
using myblog.Data;        // DbContext'in namespace'i
using myblog.Models;      // Me modelinin namespace'i
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace myblog.Controllers
{
    public class MeController : Controller
    {
        private readonly AppDbContext _context;


        public MeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Me (Listeleme)
        public async Task<IActionResult> Index()
        {
            var allMe = await _context.Set<Me>().ToListAsync();
            return View(allMe);
        }

        // GET: Me/Details/5 (Detay)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var me = await _context.Set<Me>().FirstOrDefaultAsync(m => m.Id == id);
            if (me == null) return NotFound();

            return View(me);
        }

        // GET: Me/Create (Yeni oluşturma formu)
        public IActionResult Create()
        {
            return View();
        }

        // POST: Me/Create (Yeni kayıt ekleme)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Me me)
        {
            if (ModelState.IsValid)
            {
                _context.Add(me);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(me);
        }

        // GET: Me/Edit/5 (Düzenleme formu)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var me = await _context.Set<Me>().FindAsync(id);
            if (me == null) return NotFound();

            return View(me);
        }

        // POST: Me/Edit/5 (Güncelleme)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Me me)
        {
            if (id != me.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(me);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeExists(me.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(me);
        }

        // GET: Me/Delete/5 (Silme onay sayfası)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var me = await _context.Set<Me>().FirstOrDefaultAsync(m => m.Id == id);
            if (me == null) return NotFound();

            return View(me);
        }

        // POST: Me/Delete/5 (Silme işlemi)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var me = await _context.Set<Me>().FindAsync(id);
            if (me != null)
            {
                _context.Set<Me>().Remove(me);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MeExists(int id)
        {
            return _context.Set<Me>().Any(e => e.Id == id);
        }
        // POST: Me/UpdateMe
        [HttpPost]
        [IgnoreAntiforgeryToken] // AJAX çağrısı için, AntiForgery token kullanmıyorsan
        public async Task<IActionResult> UpdateMe([FromBody] UpdateRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.NewValue))
            {
                return Json(new { success = false, message = "Geçersiz veri." });
            }

            var meItem = await _context.Me.FindAsync(request.Id);
            if (meItem == null)
            {
                return Json(new { success = false, message = "Kayıt bulunamadı." });
            }

            meItem.Name = request.NewValue;

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
