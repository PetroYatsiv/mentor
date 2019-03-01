using System;
using Xunit;
using Moq;
using Forum.Data.Repository.EntityRepository;
using Microsoft.EntityFrameworkCore;
using Forum.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Forum.Data.Tests
{
    public class UnitTest1
    {
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

        [Fact]
        public void Get_Method_Return_One_Value()
        {
            //Arrange
            var commentStub = new List<Comment>()
            {
                new Comment() {Id = 1, SubTopicId = 1, CommentText = "Comment Text" },
                new Comment(),
                new Comment()
            };

            DbSet<Comment> dbSetComments = GetQueryableMockDbSet(commentStub);
            var forumDatabaseContext = new Mock<ForumDatabaseContext>();
            forumDatabaseContext.Setup(c => c.Comments).Returns(dbSetComments);
            CommentRepository commentRepository = new CommentRepository(forumDatabaseContext.Object);

            //Act
            var expectedResults = commentRepository.Get(1);


            //Assert
            Assert.Equal(expectedResults, commentStub.First());
        }

        //DbSet<T> test<T>(T comment) where T : class
        //{
            
        //    var dbSet = new Mock<DbSet<T>>();
        //    dbSet.Setup(m => )

        //    return dbSet.Object;
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
