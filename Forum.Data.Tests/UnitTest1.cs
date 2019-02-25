using System;
using Xunit;
using Moq;
using Forum.Data.Repository.EntityRepository;
using Microsoft.EntityFrameworkCore;
using Forum.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Data.Tests
{
    public class UnitTest1
    {

        //private ForumDatabaseContext context;
        //private CommentRepository repository;

        //public UnitTest1()
        //{
        //    context = new ForumDatabaseContext();
        //    repository = new CommentRepository(context);
        //}

        [Fact]
        public void GetAll_CallMethod_NotNull()
        {
            //Arrange
            var commentStub = new List<Comment>()
            {
                new Comment() {Id = 1},
                new Comment(),
                new Comment()
            };

            DbSet<Comment> dbSetComments = GetQueryableMockDbSet(commentStub);

            var forumDatabaseContext = new Mock<ForumDatabaseContext>();
            forumDatabaseContext.Setup(c => c.Comments).Returns(dbSetComments);

            CommentRepository commentRepository = new CommentRepository(forumDatabaseContext.Object);

            //Act
            var actualComments = commentRepository.GetAll();

            //Assert
            Assert.Equal(actualComments.Count(), commentStub.Count());
            Assert.Equal(actualComments.First().Id, commentStub.First().Id);
        }

        //[Fact]
        //public void Get_CallMethod_Count1()
        //{
        //    //Arrange
        //    var mock = new Mock<CommentRepository>();
        //    mock.Setup(repo => repo.Get(1)).Returns(GetTestComment);
        //    //Act
        //    Comment expected = repository.Get(1);
        //    //var expected = repository.Get(1);
        //    Comment comment = new Comment();

        //    //Assert
        //    Assert.Equal(1,expected);


        //}
        //private Comment GetTestComment()
        //{
        //    return new Comment
        //    {
        //        Id = 1,
        //        CommentDate = DateTime.Now,
        //        CommentText = "Some Comment Test",
        //        SubTopicId = 1,
        //        SubTopic = new SubTopic()
        //    };
        //}


        DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return dbSet.Object;
        }
    }
}
