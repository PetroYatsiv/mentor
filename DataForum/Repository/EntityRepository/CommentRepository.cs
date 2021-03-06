﻿using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public void Update(int id, Comment item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public Comment Get(int id)
        {
            var result = _db.Comments.Find(id);
            return result;
        }

        public IEnumerable<Comment> GetAll()
        {
            var result = _db.Comments;
            return result;
        }
    }
}
