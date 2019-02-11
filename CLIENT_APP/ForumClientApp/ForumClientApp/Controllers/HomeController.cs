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
using ForumClientApp.Contracts;

namespace ForumClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISectionService _sectionService;

        public HomeController(ISectionService sectionService)
        {
            _sectionService = sectionService;
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

        public IActionResult EditSection(int id, SectionViewModel section)
        {
            _sectionService.UpdateSection(id, section);
            return RedirectToAction("Index");
        }
    }
}
