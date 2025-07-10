using Microsoft.AspNetCore.Mvc;
using myblog.Data;
using myblog.Models;
using myblog.Models.ViewModel; // ViewModel burada yer almalı
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

        public IActionResult Index()
        {
            var model = new ViewModel
            {
                User = _context.User.ToList(),
                Education = _context.Educations.ToList(),
                Skills = _context.Skills.ToList(),
                Lang = _context.Lang.ToList(),
                SLang = _context.SLang.ToList(),
                Text = _context.Text.ToList()
            };

            return View(model);
        }
    }
}
