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
        private UnitOfWork _unitOfWork;

        public CommentController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET api/section
        [HttpGet]
        public IActionResult GetValues()
        {
            var comments = _unitOfWork.Comments.GetAll();
            return Ok(comments);
        }

        public IActionResult GetValue(int id)
        {
            var value = _unitOfWork.Comments.Get(id);
            return Ok(value);
        }
        [HttpPost]
        public void Post(Comment comment)
        {
            _unitOfWork.Comments.Create(comment);
            _unitOfWork.Save();
        }
        // PUT api/comment/5
        [HttpPut("{id}")]
        public void Put(int id, Comment comment)
        {
            _unitOfWork.Comments.Update(id, comment);
            _unitOfWork.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Comments.Delete(id);
            _unitOfWork.Save();
        }
    }
}
