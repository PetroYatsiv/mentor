using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Data;
using Forum.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        UnitOfWork unitOfWork;
        private readonly ForumDatabaseContext _context;
        public SectionController(ForumDatabaseContext context)
        {
            unitOfWork = new UnitOfWork();
            _context = context;
        }

        //GET api/section
         [HttpGet]
        public IActionResult GetValues()
        {
            var sections = unitOfWork.Sections.GetAll();
            return Ok(sections);
        }

        // GET api/section/5
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = unitOfWork.Sections.Get(id);
            return Ok(value);
        }

        // POST api/section
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/section/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/section/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.Sections.Delete(id);
        }
    }
}
