using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ForumClientApp.Models;
using ForumClientApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForumClientApp.Controllers
{
    public class TopicController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TopicService _topicService;
        public TopicController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _topicService = new TopicService(_httpClientFactory);
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
    }
}
