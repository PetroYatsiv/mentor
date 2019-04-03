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
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult UpdateComment(int id, CommentViewModel comment)
        {
            _commentService.UpdateComment(id, comment);
            return RedirectToAction("Index", "SubTopic", new {id = comment.SubTopicId });
        }

        public IActionResult CreateNewComment(CommentViewModel comment)
        {
            comment.CommentDate = DateTime.Now;
            _commentService.CreateNewComment(comment);
            return RedirectToAction("Index", "SubTopic", new { id = comment.SubTopicId });
        }

        public IActionResult DeleteComment(int id, int SubTopicId)
        {
            _commentService.DeleteComment(id);
            return RedirectToAction("Index", "SubTopic", new { id = SubTopicId });
        }
    }
}
