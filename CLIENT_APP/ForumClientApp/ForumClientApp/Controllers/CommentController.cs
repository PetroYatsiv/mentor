using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumClientApp.Contracts;
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
            return View();
        }
    }
}
