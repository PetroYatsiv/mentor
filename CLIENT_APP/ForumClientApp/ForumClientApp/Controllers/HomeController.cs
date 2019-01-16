using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumClientApp.Models;
using ForumClientApp.Services;
using Forum.Data.Models;
using System.Collections;

namespace ForumClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SectionService _sectionService;
        public HomeController()
        {
            _sectionService = new SectionService();
        }

        public async Task<IActionResult> Index()
        {
            var sections = _sectionService.GetSections();

            return View(sections);
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
