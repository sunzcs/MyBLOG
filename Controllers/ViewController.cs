using Microsoft.AspNetCore.Mvc;
using myblog.Data;
using myblog.Models.ViewModel;
using System.Linq;

namespace myblog.Controllers
{
    public class ViewController : Controller
    {
        private readonly AppDbContext _context;

        public ViewController(AppDbContext context)
        {
            _context = context;
        }
        
            public IActionResult UpdateName(int id)
                    {
                        var me = _context.Me.FirstOrDefault(m => m.Id == id);
                        if (me != null)
                        {
                            me.Name = "Yeni İsim";
                            _context.SaveChanges();
                            return Content("Güncellendi!");
                        }
                        return Content("Kayıt bulunamadı.");
                    }

        // 🔹 Ana Sayfa
        public IActionResult _AnaSayfa()
        {
            var model = new ViewModel
            {
                Me = _context.Me.ToList(),
                Education = _context.Education.ToList(),
                Skills = _context.Skills.ToList(),
                Lang = _context.Lang.ToList(),
                SLang = _context.SLang.ToList()
            };

            return View(model);
        }

        // 🔹 Becerilerim
        public IActionResult _Becerilerim()
        {
            var model = new ViewModel
            {
                Skills = _context.Skills.ToList(),
                SLang = _context.SLang.ToList(),
                Lang = _context.Lang.ToList()
            };

            return View(model); 
        }

        // 🔹 Hakkımda
        public IActionResult _Hakkımda()
        {
            var model = new ViewModel
            {
                Me = _context.Me.ToList(),
                Education = _context.Education.ToList()
            };

            return View(model); 
        }

        // 🔹 İletişim
        public IActionResult _İletişim()
        {
            var model = new ViewModel
            {
                Me = _context.Me.ToList()
            };

            return View(model); 
        }

        // 🔹 Projelerim
        public IActionResult _Projelerim()
        {
            

            var model = new ViewModel
            {
                Me = _context.Me.ToList() 
            };

            return View(model); 
        }
    }
}
