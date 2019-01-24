using Forum.Data;
using Forum.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        UnitOfWork unitOfWork;
        private readonly ForumDatabaseContext _context;

        public CommentController(ForumDatabaseContext context)
        {
            _context = context;
        }

        //GET api/section
        [HttpGet]
        public IActionResult GetValues()
        {
            var comments = unitOfWork.Comments.GetAll();
            return Ok(comments);
        }

        public IActionResult GetValue(int id)
        {
            var value = unitOfWork.Comments.Get(id);
            return Ok(value);
        }
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.Comments.Delete(id);
        }
    }
}
