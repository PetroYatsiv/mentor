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
        private readonly ForumDatabaseContext _context;

        public TopicController(ForumDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Topics.ToListAsync();
            return Ok(values);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetValue(int id)
        //{

        //}
    }
}
