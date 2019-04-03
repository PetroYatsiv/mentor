using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Data.Repository.EntityRepository
{
    public class SubTopicRepository : IRepository<SubTopic>
    {
        private ForumDatabaseContext _db;
        public SubTopicRepository(ForumDatabaseContext context)
        {
            _db = context;
        }

        public SubTopic Get(int id)
        {
            return _db.SubTopics.Include(x => x.Comments).Where(x => x.Id == id).First();
        }

        public void Create(SubTopic item)
        {
            _db.SubTopics.Add(item);
        }

        public void Delete(int id)
        {
            SubTopic subTopic = _db.SubTopics.Find(id);
            if (subTopic != null)
            {
                _db.SubTopics.Remove(subTopic);
            }
        }

        public void Update(int id, SubTopic item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

       

        public IEnumerable<SubTopic> GetAll()
        {
            return _db.SubTopics;
        }

        
    }
}
