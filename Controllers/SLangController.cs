using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;

namespace myblog.Controllers {

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
    }
}