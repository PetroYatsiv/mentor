using Forum.Data;
using Forum.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        public TopicController()
        {
            _unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public  IActionResult GetValues()
        {
            var values = _unitOfWork.Topics.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var topic = _unitOfWork.Topics.Get(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        // POST api/topic
        [HttpPost]
        public void Post(Topic topic)
        {
            _unitOfWork.Topics.Create(topic);
            _unitOfWork.Save();
        }

        // PUT api/topic/5
        [HttpPut("{id}")]
        public void Put(int id, Topic topic)
        {
            _unitOfWork.Topics.Update(id, topic);
            _unitOfWork.Save();
        }

        // DELETE api/topic/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Topics.Delete(id);
            _unitOfWork.Save();
        }
    }
}
