using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumClientApp.Models;
using ForumClientApp.Services;
using Forum.Data.Models;
using System.Collections;
using System.Net.Http;

namespace ForumClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SectionService _sectionService;

        public HomeController(IHttpClientFactory clientFactory )
        {
            _httpClientFactory = clientFactory;
            _sectionService = new SectionService(_httpClientFactory);
        }

        public IActionResult Index()
        {
            var sections = _sectionService.GetSections();
            return View(sections);
        }
    }
}
