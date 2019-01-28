using Forum.Data.Models;
using System;
using System.Collections.Generic;
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
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public SubTopic Get(int id)
        {
            return _db.SubTopics.Find(id);
        }

        public IEnumerable<SubTopic> GetAll()
        {
            return _db.SubTopics;
        }

        
    }
}
