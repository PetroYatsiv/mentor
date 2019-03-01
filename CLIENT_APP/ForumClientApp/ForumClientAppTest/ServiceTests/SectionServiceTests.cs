using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using System.Net.Http;
using ForumClientApp.Services;
using ForumClientApp.Models;

namespace ForumClientAppTest.ServiceTests
{
    public class SectionServiceTests
    {
        [Fact]
        public void GetSectionsTest()
        {
            //Arrange
            var testValue = new SectionViewModel();
            var testReturnValue = new List<SectionViewModel>();
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();

            SectionService service = new SectionService(httpClientFactoryMock);
            var expected = service.CreateNewSection(testValue).Returns(testReturnValue);

            
            //Act


            //Assert

        }
    }
}
