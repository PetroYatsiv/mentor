using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Forum.Data.Repository.EntityRepository
{
    public class SectionRepository : IRepository<Section>
    {
        private ForumDatabaseContext _db;
        public SectionRepository(ForumDatabaseContext context)
        {
            _db = context;
        }

        public Section Get(int id)
        {
            return _db.Sections.Find(id);
        }

        public IEnumerable<Section> GetAll()
        {
            return _db.Sections.Include(x => x.Topics).ToList();
        }

        public void Create(Section section)
        {
           _db.Sections.Add(section);
        }

        public void Delete(int id)
        {
            Section section = _db.Sections.Find(id);
            if (section != null)
            {
                _db.Sections.Remove(section);
            }
        }

        public void Update(int id, Section item)
        {
            _db.Entry(item).State = EntityState.Modified; 
        }
    }
}
