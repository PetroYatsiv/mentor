using System;
using Xunit;
using ForumClientApp.Contracts;
using ForumClientApp.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ForumClientApp.Services;
using System.Net.Http;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var test = new Mock<ISectionService>();
            test.Setup(x => x.GetSections()).Returns<System.Collections.Generic.List<ForumClientApp.Models.SectionViewModel>>(null);
            HomeController controller = new HomeController(test.Object);

            //Act
            var result = controller.Index() as NoContentResult;

            //Assert
            Assert.NotNull(result);
            //Assert.Equal("Index.cshtml", result?.ViewName);
            //Assert.Null(result);
        }

        [Fact]
        public void TestSectionService()
        {
            //var sectionService = new Mock<HttpClientFactory>();


            //var result = sectionService.ge
        }
    }
}
