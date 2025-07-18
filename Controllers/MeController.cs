using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;
using System;
using System.Threading.Tasks;

namespace myblog.Controllers
{
    public class MeController : Controller
    {
        private readonly AppDbContext _context;

        public MeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Me
        public async Task<IActionResult> Index()
        {
            return View(await _context.Me.ToListAsync());
        }

        // GET: Me/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var me = await _context.Me
                .FirstOrDefaultAsync(m => m.Id == id);

            if (me == null) return NotFound();

            return View(me);
        }

        // GET: Me/Create
        public IActionResult Create()
        {
            return View();
        }

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

        // GET: Me/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var me = await _context.Me.FindAsync(id);
            if (me == null) return NotFound();

            return View(me);
        }

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
                    if (!await MeExistsAsync(me.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(me);
        }

        // GET: Me/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var me = await _context.Me
                .FirstOrDefaultAsync(m => m.Id == id);

            if (me == null) return NotFound();

            return View(me);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var me = await _context.Me.FindAsync(id);
            if (me != null)
            {
                _context.Me.Remove(me);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult UpdateAll([FromBody] Me updated)
        {
            if (updated==null)
            {
                return Json(new { success = false, message = "boş veri." });
            }
            var me = _context.Me.FirstOrDefault(x => x.Id == updated.Id);
            if (me == null) return Json(new { success = false, message = "Kullanıcı bulunamadı." });

            me.Name = updated.Name;
            me.Surname = updated.Surname;
            me.Email = updated.Email;
            me.Phonenum = updated.Phonenum;
            me.Birthday = updated.Birthday;
            me.Address = updated.Address;

            _context.SaveChanges();

            return Json(new { success = true });
        }

        private async Task<bool> MeExistsAsync(int id)
        {
            return await _context.Me.AnyAsync(e => e.Id == id);
        }


    }
}
