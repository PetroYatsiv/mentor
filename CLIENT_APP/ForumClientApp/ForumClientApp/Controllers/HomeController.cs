using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumClientApp.Models;
using ForumClientApp.Services;
using Forum.Data.Models;
using WebApplication1.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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
            var sectionService = _sectionService.GetSections();
            return View();
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
