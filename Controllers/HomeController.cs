using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using myblog.Models.ViewModel;
using myblog.Data;

namespace myblog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hakkımda()
        {
            var model = new ViewModel
            {
                Me = _context.Me.ToList(),
                Education = _context.Education.ToList(),
                Skills = _context.Skills.ToList(),
                Lang = _context.Lang.ToList(),
                SLang = _context.SLang.ToList(),
                Text = _context.Text.ToList() 
            };
            return View("~/Views/Shared/AdminPages/_Hakkımda.cshtml", model);
        }
        public IActionResult AnaSayfa()
        {
            var model = new ViewModel
            {
                Me = _context.Me.ToList(),
                Education = _context.Education.ToList(),
                Skills = _context.Skills.ToList(),
                Lang = _context.Lang.ToList(),
                SLang = _context.SLang.ToList(),
                Text = _context.Text.ToList() 
            };
            return View("~/Views/Shared/AdminPages/_AnaSayfa.cshtml", model);
        }

        public IActionResult Hakkımda2()
        {
            var model = new ViewModel
            {
                Me = _context.Me.ToList(),
                Education = _context.Education.ToList(),
                Skills = _context.Skills.ToList(),
                Lang = _context.Lang.ToList(),
                SLang = _context.SLang.ToList(),
                Text = _context.Text.ToList()
            };
            return View("~/Views/Shared/AdminPages/_Hakkımda2.cshtml", model);
        }

        public IActionResult Becerilerim()
        {
            var model = new ViewModel
            {
                Me = _context.Me.ToList(),
                Education = _context.Education.ToList(),
                Skills = _context.Skills.ToList(),
                Lang = _context.Lang.ToList(),
                SLang = _context.SLang.ToList(),
                Text = _context.Text.ToList()
            };
            return View("~/Views/Shared/AdminPages/_Becerilerim.cshtml", model);
        }

        public IActionResult Projelerim()
        {
            var model = new ViewModel
            {
                Me = _context.Me.ToList(),
                Education = _context.Education.ToList(),
                Skills = _context.Skills.ToList(),
                Lang = _context.Lang.ToList(),
                SLang = _context.SLang.ToList(),
                Text = _context.Text.ToList()
            };
            return View("~/Views/Shared/AdminPages/_Projelerim.cshtml", model);
        }

        public IActionResult İletişim()
        {
            var model = new ViewModel
            {
                Me = _context.Me.ToList(),
                Education = _context.Education.ToList(),
                Skills = _context.Skills.ToList(),
                Lang = _context.Lang.ToList(),
                SLang = _context.SLang.ToList(),
                Text = _context.Text.ToList()
            };
            return View("~/Views/Shared/AdminPages/_İletişim.cshtml", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
