using Microsoft.AspNetCore.Mvc;
using myblog.Data;
using myblog.Models;
using myblog.Models.ViewModel;
using System.Linq;

namespace myblog.Controllers
{
    public class LinkController : Controller
    {
        private readonly AppDbContext _context;

        public LinkController(AppDbContext context)
        {
            _context = context;
        }

        // Link listesini ViewModel ile gönder
        public IActionResult Link()
        {
            var vm = new ViewModel
            {
                Links = _context.Links.ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public JsonResult Add([FromBody] Link link)
        {
            if (string.IsNullOrEmpty(link.LinkUrl))
                return Json(new { success = false, message = "Boş link eklenemez." });

            _context.Links.Add(link);
            _context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult UpdateAll([FromBody] Link link)
        {
            var links = _context.Links.FirstOrDefault(l => l.LinkId == link.LinkId);
            if (links == null)
                return Json(new { success = false, message = "Link bulunamadı." });

            links.LinkUrl = link.LinkUrl;
            _context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var link = _context.Links.Find(id);
            if (link == null)
                return Json(new { success = false, message = "Link bulunamadı." });

            _context.Links.Remove(link);
            _context.SaveChanges();
            return Json(new { success = true });
        }
    }
}
