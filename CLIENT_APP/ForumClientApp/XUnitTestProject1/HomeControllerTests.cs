using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using Moq;
using ForumClientApp.Controllers;
using ForumClientApp.Services;
using Microsoft.AspNetCore.Mvc;
using ForumClientApp.Models;
using AutoFixture;

namespace XUnitTestProject1
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexMthod_ReturnView()
        {
            //Arrange
            var controller = new Fixture().Create<HomeController>();
            //var Mock = new Mock<SectionService>();
            //Mock.Setup(x => x.GetSections()).Returns(GetTEstSections());
            //var controller = new HomeController(Mock.Object);

            //Act
            var expected = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(expected);
            var model = Assert.IsAssignableFrom<IEnumerable<SectionViewModel>>(viewResult.ViewData.Model);

            Assert.Equal(model.Count(), model.Count());

        }

        public List<SectionViewModel> GetTEstSections()
        {
            List<SectionViewModel> sections = new List<SectionViewModel>();
            return sections;
        }
    }
}
