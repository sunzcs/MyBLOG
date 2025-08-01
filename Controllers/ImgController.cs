using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using myblog.Data;

namespace myblog.Controllers
{
    public class ImgController : Controller
    {
        private readonly AppDbContext _context;

        public ImgController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Img()
        {
            
            var imgs = _context.Imgs.ToList();
            return View("~/Views/Shared/AdminPages/Img.cshtml", imgs);

        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var img = new Img
                {
                    ImgUrl = "/img/" + fileName
                };

                _context.Imgs.Add(img);
                _context.SaveChanges();

                return RedirectToAction("Img");
            }

            return RedirectToAction("Img");

        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var img = _context.Imgs.Find(id);
            if (img == null)
                return Json(new { success = false, message = "Resim bulunamadı." });

            _context.Imgs.Remove(img);
            _context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult UpdateAll([FromBody] Img img)
        {
            var existing = _context.Imgs.FirstOrDefault(i => i.ImageId == img.ImageId);
            if (existing == null)
                return Json(new { success = false, message = "Resim bulunamadı." });

            existing.ImgUrl = img.ImgUrl;
            _context.SaveChanges();
            return Json(new { success = true });
        }
        
        
    }
}
