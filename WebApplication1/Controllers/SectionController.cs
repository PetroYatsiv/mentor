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
        private readonly UnitOfWork _unitOfWork;
        public SectionController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
            //TODO: inject repository of work to controller
            //
        }

        //GET api/section
         [HttpGet]
        public IActionResult GetValues()
        {
            var sections = _unitOfWork.Sections.GetAll();
            if (sections == null)
            {
                return NotFound();
            }
            return Ok(sections);
        }

        // GET api/section/5
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var section = _unitOfWork.Sections.Get(id);
            if (section == null)
            {
                return NotFound();
            }
            return Ok(section);
        }

        // POST api/section
        [HttpPost]
        public void Post(Section section)
        {
            _unitOfWork.Sections.Create(section);
            _unitOfWork.Save();
        }

        // PUT api/section/5
        [HttpPut("{id}")]
        public void Put(int id, Section section)
        {
        }

        // DELETE api/section/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Sections.Delete(id);
        }
    }
}
