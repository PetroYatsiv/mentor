using Xunit;
using ForumClientApp.Contracts;
using ForumClientApp.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ForumClientApp.Models;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void IndexResultNotNull()
        {
            //Arrange
            var test = new Mock<ISectionService>();
            test.Setup(x => x.GetSections()).Returns<List<SectionViewModel>>(null);
            HomeController controller = new HomeController(test.Object);

            //Act
            var result = controller.Index() as NoContentResult;

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void IsResultisNull()
        {
            //Arrange
            var test = new Mock<ISectionService>();
            test.Setup(x => x.GetSections()).Returns<List<ForumClientApp.Models.SectionViewModel>>(null);
            HomeController controller = new HomeController(test.Object);

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.Null(result);
        }
        [Fact]
        public void RedirectToIndex()
        {
            //arange
            var section = new SectionViewModel();

            var test = new Mock<ISectionService>();
            HomeController controller = new HomeController(test.Object);

            //test.Setup(x => x.GetSections()).Returns<List<SectionViewModel>>(null);
            //test.Setup(x => x.DeleteSection(1)).Returns<List<SectionViewModel>>(null);


            //Act
            //var result = (Redi)
            var result = controller.AddNewSection(section) as RedirectToActionResult;
            //result.RouteValues["action"].Equals("Index");
            //result.RouteValues["controller"].Equals("Home");

            //Assert.Equal("Home", result.RouteValues["controller"]);
            Assert.NotNull(result);
            //Assert.Equal("Index", result.RouteValues["action"].ToString());
        }
    }
}
