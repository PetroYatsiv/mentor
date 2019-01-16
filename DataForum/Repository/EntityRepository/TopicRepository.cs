using Forum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Repository.EntityRepository
{
    public class TopicRepository : IRepository<Topic>
    {
        private ForumDatabaseContext _db;

        public TopicRepository(ForumDatabaseContext context)
        {
            _db = context;
        }

        public void Create(Topic item)
        {
            _db.Topics.Add(item);
        }

        public void Delete(int id)
        {
            Topic topic = _db.Topics.Find(id);
            if (topic != null)
            {
                _db.Topics.Remove(topic);
            }
        }

        public Topic Get(int id)
        {
            return _db.Topics.Find(id);
        }

        public IEnumerable<Topic> GetAll()
        {
            return _db.Topics;
        }

        public void Update(Topic item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
