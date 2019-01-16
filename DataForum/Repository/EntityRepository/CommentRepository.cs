using Forum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Repository.EntityRepository
{
    public class CommentRepository : IRepository<Comment>
    {
        private ForumDatabaseContext _db;
        public CommentRepository(ForumDatabaseContext context)
        {
            _db = context;
        }

        public void Create(Comment item)
        {
            _db.Comments.Add(item);
        }

        public void Delete(int id)
        {
            Comment comment = _db.Comments.Find(id);
            if (comment != null)
            {
                _db.Comments.Remove(comment);
            }
        }

        public void Update(Comment item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Comment Get(int id)
        {
            return _db.Comments.Find(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _db.Comments;
        }
    }
}
