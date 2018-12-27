using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ForumDatabaseContext _context;
        public SectionController(ForumDatabaseContext context)
        {
            _context = context;
        }

        //GET api/section
         [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Section.Include(x => x.Topics).ToListAsync();
            return Ok(values);
            //string data = "";
            //data = Request.Method;
            //return Ok(data);
        }


        // GET api/section/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Section.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // GET api/section/5
        [HttpGet("{id}/{v}")]
        public ActionResult<string> Get(int id, string v)
        {
            return "value32";
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
        }
    }
}
