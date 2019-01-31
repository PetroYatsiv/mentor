using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumClientApp.Models;
using ForumClientApp.Services;
using Forum.Data.Models;
using System.Collections;
using System.Net.Http;
using AutoMapper;

namespace ForumClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SectionService _sectionService;
        private readonly IMapper _mapper;

        public HomeController(IHttpClientFactory clientFactory, IMapper mapper )
        {
            _httpClientFactory = clientFactory;
            _sectionService = new SectionService(_httpClientFactory);
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var sections = _sectionService.GetSections();
            return View(sections);
        }
        public IActionResult AddNewSection(SectionViewModel section)
        {
            _sectionService.CreateNewSection(section);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSection(int id)
        {
            _sectionService.DeleteSection(id);
            return RedirectToAction("Index");
        }
    }
}
