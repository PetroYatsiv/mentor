using ForumClientApp.Contracts;
using ForumClientApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Xunit;
using Moq;
namespace ClassLibrary1
{
    public class Class1
    {
        [Fact]
        public void FirstTest()
        {
            var test = new Mock<ISectionService>();

            HomeController controller = new HomeController(test.Object);
            ViewResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);

            Assert.Equal("Index", result?.ViewName);
        }
    }
}
