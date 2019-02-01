using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumClientApp.Models;
using ForumClientApp.Services;
using Forum.Data.Models;
using System.Collections;
using System.Net.Http;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace ForumClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SectionService _sectionService;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
            _sectionService = new SectionService(_httpClientFactory);
        }

        public IActionResult Index()
        {
            List<SectionViewModel> sections = new List<SectionViewModel>();
            try
            {
                sections = _sectionService.GetSections();
                if (sections == null)
                {
                    return NoContent();//204 status code
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
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
