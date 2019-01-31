using Forum.Data.Models;
using Forum.Data.Repository.EntityRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data
{
    interface IUnitOfWork
    {

    }


    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ForumDatabaseContext _db = new ForumDatabaseContext();

        private SectionRepository _sectionRepository;
        private TopicRepository _topicRepository;
        private SubTopicRepository _subTopicRepository;
        private CommentRepository _commentRepository;

        public SectionRepository Sections
        {
            get
            {
                if (_sectionRepository == null)
                    _sectionRepository = new SectionRepository(_db);
                    return _sectionRepository;
            }
        }

        public TopicRepository Topics
        {
            get
            {
                if (_topicRepository == null)
                    _topicRepository = new TopicRepository(_db);
                return _topicRepository;
            }
        }

        public SubTopicRepository SubTopics
        {
            get
            {
                if (_subTopicRepository == null)
                    _subTopicRepository = new SubTopicRepository(_db);
                return _subTopicRepository;
            }
        }

        public CommentRepository Comments
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_db);
                return _commentRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
