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
            var t = _db.Sections.Include(x => x.Topics).ToList();
            return t;
            //return _db.Sections.Include(x => x.Topics);
            //return _db.Sections;
        }

        public void Create(Section item)
        {
            _db.Sections.Add(item);
        }

        public void Delete(int id)
        {
            Section section = _db.Sections.Find(id);
            if (section != null)
            {
                _db.Sections.Remove(section);
            }
        }

        public void Update(Section item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
