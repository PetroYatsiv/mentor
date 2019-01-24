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
        private readonly TopicService _topicService;

        public HomeController(IHttpClientFactory clientFactory )
        {
            _httpClientFactory = clientFactory;
            _sectionService = new SectionService();
            _topicService = new TopicService(_httpClientFactory);
        }

        public async Task<IActionResult> Index()
        {
            var sections = _sectionService.GetSections();
            var topics = _topicService.GetTopics();

            return View(sections);
        }

        [HttpPost]
        public string CreateSection(Models.Section section)
        {
            _sectionService.CreateNewSection();
            return "ok";
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
