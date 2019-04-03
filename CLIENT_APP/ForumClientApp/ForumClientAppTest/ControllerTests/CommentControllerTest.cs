using System;
using System.Collections.Generic;
using System.Text;
using ForumClientApp.Contracts;
using ForumClientApp.Controllers;
using ForumClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace ForumClientAppTest.ControllerTests
{
    public class CommentControllerTest
    {
        [Fact]
        public void Index_return_Index_View()
        {
            //Arrange

            var service = Substitute.For<ICommentService>();
            CommentController controller = new CommentController(service);

            //Act
            var expected = controller.Index() as ViewResult;

            //Assert
            Assert.Equal("Index", expected?.ViewName);
        }


        [Fact]
        public void Update_Comment_Return_Value_Redirect_To_Action()
        {
            //Arrange
            List<CommentViewModel> returnValue = new List<CommentViewModel>();
            CommentViewModel comment = new CommentViewModel() { Id = 1, SubTopicId = 1 };

            var commentService = Substitute.For<ICommentService>();
            commentService.UpdateComment(1, comment).Returns(returnValue);
            CommentController controller = new CommentController(commentService);

            //Act
            var expected = controller.UpdateComment(1, comment) as RedirectToActionResult;

            //Assert
            Assert.Equal(expected.ActionName, "Index");
            Assert.Equal(expected.ControllerName, "SubTopic");

        }
    }
}



