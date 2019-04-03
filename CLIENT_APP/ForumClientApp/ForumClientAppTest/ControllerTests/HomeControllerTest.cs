using System;
using Xunit;
using NSubstitute;
using ForumClientApp.Contracts;
using ForumClientApp.Controllers;
using ForumClientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumClientAppTest
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexMthod_ReturnView()
        {
            //Arrange
            var service = Substitute.For<ISectionService>();
            HomeController controller = new HomeController(service);

            //Act
            var expected = controller.Index() as NoContentResult;

            //Assert
            Assert.NotNull(expected.StatusCode);
        }

        [Fact]
        public void IndexMthod_ReturnStatusCode()
        {
            //Arrange
            var service = Substitute.For<ISectionService>();
            HomeController controller = new HomeController(service);

            //Act
            var expected = controller.Index() as NoContentResult;

            //Assert
            Assert.Equal(expected.StatusCode, 204);
        }

        [Fact]
        public void Add_New_Section_Redirect_Action_To_Index()
        {
            //Arrange
            var service = Substitute.For<ISectionService>();
            HomeController controller = new HomeController(service);
            SectionViewModel section = new SectionViewModel();

            //Act
            var expected = controller.AddNewSection(section) as RedirectToActionResult;

            //Assert
            Assert.Equal(expected.ActionName, "Index");
        }
    }
}
