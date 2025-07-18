using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using myblog.Data;
using System.Diagnostics;

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

        public IActionResult AnaSayfa()
        {
            var me = _context.Me.FirstOrDefault(); // Liste değil, tek kişi
            return View("~/Views/Shared/AdminPages/_AnaSayfa.cshtml", me);
        }

        public IActionResult Hakkımda()
        {
            var educationList = _context.Education.ToList();
            return View("~/Views/Shared/AdminPages/_Hakkımda.cshtml", educationList);
        }

        public IActionResult Hakkımda2()
        {
            var langList = _context.Lang.ToList();
            return View("~/Views/Shared/AdminPages/_Hakkımda2.cshtml", langList);
        }

        public IActionResult Becerilerim()
        {
            var skillsList = _context.Skills.ToList();
            return View("~/Views/Shared/AdminPages/_Becerilerim.cshtml", skillsList);
        }

        public IActionResult Projelerim()
        {
            var textList = _context.Text.ToList();
            return View("~/Views/Shared/AdminPages/_Projelerim.cshtml", textList);
        }

        public IActionResult İletişim()
        {
            var slangList = _context.SLang.ToList();
            return View("~/Views/Shared/AdminPages/_İletişim.cshtml", slangList);
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
