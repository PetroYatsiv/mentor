using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using ForumClientApp.Controllers;
using ForumClientApp.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ForumClientAppTest.ControllerTests
{
    public class SubTopicControllerTest
    {
        [Fact]
        public void return_View_Add_Model()
        {
            //Arrange
            var subtopicService = Substitute.For<ISubtopicService>();
            SubTopicController controller = new SubTopicController(subtopicService);


            //Act
            var expectedView = controller.Index(1) as ViewResult;


            //Assert
            Assert.Equal("Index", expectedView?.ViewName);
        }
    }
}
