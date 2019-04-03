using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ForumClientApp.Contracts;
using ForumClientApp.Models;
using ForumClientApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForumClientApp.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        // GET: /<controller>/
        public IActionResult Index(int Id)
        {
          var topic =  _topicService.GetTopic(Id);
            return View(topic);
        }

        public IActionResult CreateNewTopic(TopicViewModel topic)
        {
            _topicService.CeateNewTopic(topic);
            return RedirectToAction("Index","Home");
        }

        public IActionResult UpdateTopic(int id, TopicViewModel topic)
        {
            _topicService.UpdateTopic(id, topic);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteTopic(int id)
        {
            _topicService.DeleteTopic(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
