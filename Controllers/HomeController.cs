using Microsoft.AspNetCore.Mvc;
using myblog.Models;
using myblog.Data;
using System.Diagnostics;
using myblog.Models.ViewModel;
using System.Linq;
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
                Skills = _context.Skills.ToList(),  // Burada ToList() kullandık, çünkü ViewModel'deki Skills List<Skills> tipinde
                Text = _context.Text.Find(1),
                Lang = _context.Lang.ToList(),
                Links = _context.Links.ToList(),
                Imgs = _context.Imgs.ToList()      // Eğer Lang List ise burayı da ekledim
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
            var skills = _context.Skills.ToList(); // Tüm kayıtları al
            return View("~/Views/Shared/AdminPages/Skills.cshtml", skills); // Listeyi view'a gönder
        }


        public IActionResult Lang()
        {
            var lang = _context.Lang.ToList();
            return View("~/Views/Shared/AdminPages/Lang.cshtml", lang);
        }

        public IActionResult Text()
        {
            var text = _context.Text.FirstOrDefault();
            return View("~/Views/Shared/AdminPages/Text.cshtml", text);
        }
        public IActionResult Img()
        {
            var img = _context.Imgs.ToList();
            return View("~/Views/Shared/AdminPages/Img.cshtml", img);
        }
        public IActionResult Link()
        {
            var link = _context.Links.ToList();
            return View("~/Views/Shared/AdminPages/Link.cshtml", link);
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
