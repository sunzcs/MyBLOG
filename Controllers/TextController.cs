using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;

namespace myblog.Controllers
{
    public class TextController : Controller
    {
        private readonly AppDbContext _context;
        public TextController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.Text.ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Text text)
        {
            if (!ModelState.IsValid) return View(text);
            _context.Text.Add(text);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Text.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Text text)
        {
            _context.Text.Update(text);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Text.FindAsync(id);
            if (item == null) return NotFound();
            _context.Text.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
