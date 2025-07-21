using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using myblog.Data;
using System.Diagnostics;
using myblog.Models.ViewModel;

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
            var viewModel = new ViewModel
            {
                Me = _context.Me.Find(1),
                Education = _context.Education.Find(1),
                Skills = _context.Skills.Find(1),
                Text = _context.Text.Find(1)

            };
            return View(viewModel);
        }

        public IActionResult Me()
        {
            var me = _context.Me.FirstOrDefault(); // Liste değil, tek kişi
            return View("~/Views/Shared/AdminPages/Me.cshtml", me);
        }

        public IActionResult Education()
        {
            var education = _context.Education.FirstOrDefault();
            return View("~/Views/Shared/AdminPages/Education.cshtml", education);
        }


        public IActionResult Skills()
        {
            var skills = _context.Skills.FirstOrDefault();
            return View("~/Views/Shared/AdminPages/Skills.cshtml", skills);
        }

        public IActionResult Lang()
        {
            var Lang = _context.Lang.FirstOrDefault();
            return View("~/Views/Shared/AdminPages/Lang.cshtml", Lang);
        }

        public IActionResult Text()
        {
            var text = _context.Text.FirstOrDefault();
            return View("~/Views/Shared/AdminPages/Text.cshtml", text);
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
