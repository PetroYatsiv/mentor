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
    public class ValuesController : ControllerBase
    {
        private readonly ForumDatabaseContext _context;
        public ValuesController(ForumDatabaseContext context)
        {
            _context = context;
        }

        //GET api/values
         [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Section.ToListAsync();
            return Ok(values);
            //string data = "";
            //data = Request.Method;
            //return Ok(data);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Section.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // GET api/values/5
        [HttpGet("{id}/{v}")]
        public ActionResult<string> Get(int id, string v)
        {
            return "value32";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
