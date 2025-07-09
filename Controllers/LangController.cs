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
    }
}
