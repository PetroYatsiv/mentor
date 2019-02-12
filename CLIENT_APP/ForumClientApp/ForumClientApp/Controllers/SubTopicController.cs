using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumClientApp.Contracts;
using ForumClientApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForumClientApp.Controllers
{
    public class SubTopicController : Controller
    {
        private readonly ISubtopicService _subtopicService;
        public SubTopicController(ISubtopicService subtopicService)
        {
            _subtopicService = subtopicService;
        }
        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            var subTopic = _subtopicService.GetSubTopic(id);
            return View(subTopic);
        }

        public IActionResult Create(SubTopicViewModel subTopicViewModel)
        {
            _subtopicService.CreateNewSubTopic(subTopicViewModel);
           return RedirectToAction("Index","Topic", new {id = subTopicViewModel.TopicId });
        }

        public IActionResult EditSubTopic(int id, SubTopicViewModel subTopicViewModel)
        {
            _subtopicService.UpdateSubTopic(id, subTopicViewModel);
            return RedirectToAction("Index", "Topic", new { id = subTopicViewModel.TopicId });
        }

        public IActionResult DeleteSubTopic(int id, int topicId)
        {
            _subtopicService.DeleteSubTopic(id);
            return RedirectToAction("Index", "Topic", new { id = topicId });
        }
    }
}
