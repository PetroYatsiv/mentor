using ForumClientApp.Contracts;
using ForumClientApp.Controllers;
using ForumClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumClientAppTest.ControllerTests
{
    public class TopicControllerTests
    {
        [Fact]
        public void Return_Model_Index_Method()
        {
            //Arrange
            var testValue = new TopicViewModel() { Id = 1 };
            var service = Substitute.For<ITopicService>();
            service.GetTopic(1).Returns(testValue);
            TopicController controller = new TopicController(service);

            //Act
            var expected = controller.Index(1) as ViewResult;

            //Assert
            Assert.Equal(expected.Model, testValue);
            Assert.NotNull(expected);
        }

        [Fact]
        public void Redirect_To_Action_Create_New_Topic()
        {
            //Arrange
            var testValue = new TopicViewModel() { Id = 2 };
            var service = Substitute.For<ITopicService>();
            TopicController controller = new TopicController(service);

            //Act
            var expected = controller.CreateNewTopic(testValue) as RedirectToActionResult;

            //Assert
            Assert.Equal(expected.ActionName, "Index");
            Assert.Equal(expected.ControllerName, "Home");
        }
    }
}
