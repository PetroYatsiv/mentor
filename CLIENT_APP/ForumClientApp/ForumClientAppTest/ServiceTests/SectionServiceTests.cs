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
        public void Get_Sections_Return_List_Of_Value()
        {
            //Arrange
            var testValue = new SectionViewModel();
            var testReturnValue = new List<SectionViewModel>();
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();

            var serviceBase = Substitute.For<ServiceBase>(httpClientFactoryMock, Clients.SectionClient);
            SectionService service = new SectionService(httpClientFactoryMock);

            //Act
            var expected = service.CreateNewSection(testValue);

            //Assert
            Assert.Equal(expected, testReturnValue);
        }


        [Fact]
        public void Update_Section_Return_List_Of_SectionViewModel()
        {
            //Arrange
            var testReturnValue = new List<SectionViewModel>();
            var testValue = new SectionViewModel();
            var httpClientFactory = Substitute.For<IHttpClientFactory>();
            var serviceBase = Substitute.For<ServiceBase>(httpClientFactory, Clients.SectionClient);
            SectionService service = new SectionService(httpClientFactory);

            //Act
            var expected = service.UpdateSection(1, testValue);

            //Assert
            Assert.Equal(expected, testReturnValue);
        }
    }
}
