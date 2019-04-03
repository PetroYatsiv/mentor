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
    public class SubTopicController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        public SubTopicController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/subTopic/5
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var subTopic = _unitOfWork.SubTopics.Get(id);
            if (subTopic == null)
            {
                return NotFound();
            }
            return Ok(subTopic);
        }

        // POST api/subTopic
        [HttpPost]
        public void Post(SubTopic subTopic)
        {
            _unitOfWork.SubTopics.Create(subTopic);
            _unitOfWork.Save();
        }

        // PUT api/subTopic/5
        [HttpPut("{id}")]
        public void Put(int id, SubTopic subTopic)
        {
            _unitOfWork.SubTopics.Update(id, subTopic);
            _unitOfWork.Save();
        }

        // DELETE api/subTopic/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.SubTopics.Delete(id);
            _unitOfWork.Save();
        }
    }
}
