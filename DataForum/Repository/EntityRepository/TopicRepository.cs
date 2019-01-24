using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Forum.Data.Repository.EntityRepository
{
    public class TopicRepository : IRepository<Topic>
    {
        private ForumDatabaseContext _db;
        public TopicRepository(ForumDatabaseContext context)
        {
            _db = context;
        }

        public Topic Get(int id)
        {
            var topic = _db.Topics.Include(x => x.SubTopics).Where(x => x.Id == id).First();
            return topic;
        }

        public IEnumerable<Topic> GetAll()
        {
            return _db.Topics.Include(x => x.SubTopics);
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

       

        

        public void Update(Topic item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
