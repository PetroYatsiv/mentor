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
        UnitOfWork unitOfWork;
        public TopicController()
        {
            unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public  IActionResult GetValues()
        {
            var values = unitOfWork.Topics.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var topic = unitOfWork.Topics.Get(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }
    }
}
