using Forum.WebApi.Controllers;
using System;
using Xunit;
using Moq;
using Forum.Data;
using Forum.Data.Repository.EntityRepository;
using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebApi.Tests
{
    public class CommentControllersTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            UnitOfWork unitOfWork = new UnitOfWork();
            CommentController controller = new CommentController(unitOfWork);

            //Act
            var excepted = controller.GetValue(1);
            
            //Assert
            //Assert.
        }
    }
}
