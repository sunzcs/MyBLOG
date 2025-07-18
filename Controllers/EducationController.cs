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
        [Route("Education/UpdateEducation")]
        public async Task<IActionResult> UpdateEducation([FromBody] UpdateRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.PropertyName) || string.IsNullOrWhiteSpace(request.NewValue))
                return Json(new { success = false, message = "Eksik veri." });

            var education = await _context.Education.FindAsync(request.Id);
            if (education == null)
                return Json(new { success = false, message = "Kayıt bulunamadı." });

            try
            {
                switch (request.PropertyName)
                {
                    case "SCName":
                        education.SCName = request.NewValue;
                        break;
                    case "SCStatement":
                        education.SCStatement = request.NewValue;
                        break;
                    case "SCStartdate":
                        if (DateTime.TryParse(request.NewValue, out var start))
                            education.SCStartdate = start;
                        else return Json(new { success = false, message = "Geçersiz tarih." });
                        break;
                    case "SCFinishdate":
                        if (DateTime.TryParse(request.NewValue, out var finish))
                            education.SCFinishdate = finish;
                        else return Json(new { success = false, message = "Geçersiz tarih." });
                        break;
                    default:
                        return Json(new { success = false, message = "Tanımsız alan." });
                }

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
