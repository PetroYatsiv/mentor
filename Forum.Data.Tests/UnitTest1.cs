using System;
using Xunit;
using Moq;
using Forum.Data.Repository.EntityRepository;
using Microsoft.EntityFrameworkCore;
using Forum.Data.Models;
using System.Collections.Generic;

namespace Forum.Data.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetAll_CallMethod_NotNull()
        {
            //Arrange
            ForumDatabaseContext forumDatabaseContext = new ForumDatabaseContext();
            CommentRepository commentRepository = new CommentRepository(forumDatabaseContext);

            //Act
            var expected = commentRepository.GetAll();

            //Assert
            Assert.NotNull(expected);

        }

        [Fact]
        public void Get_CallMethod_Count1()
        {
            //Arrange
            ForumDatabaseContext context = new ForumDatabaseContext();
            CommentRepository commentRepository = new CommentRepository(context);


            //Act
            Comment expected = commentRepository.Get(2);
            Comment comment = new Comment();

            //Assert
            Assert.Equal(comment.GetType().ToString(), expected.GetType().ToString());


        }
    }
}
