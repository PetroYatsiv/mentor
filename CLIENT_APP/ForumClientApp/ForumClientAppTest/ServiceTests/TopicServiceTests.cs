using Xunit;
using NSubstitute;
using ForumClientApp.Contracts;
using ForumClientApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ForumClientApp.Models;
using ForumClientApp.Services;
using System.Net.Http;

namespace ForumClientAppTest.ServiceTests
{
    public class TopicServiceTests
    {
        [Fact]
        public void ReturnSections()
        {
            //Arrange
        //    var testValue = new List<TopicViewModel>();

        //    var clientFactory = Substitute.For<IHttpClientFactory>();
        //    var client = clientFactory.CreateClient("TopicClient").Returns(new HttpClient());

        //    TopicService service = new TopicService(clientFactory);
        //    service.GetTopics().Returns(testValue);

        //    //Act
        //    var expected = service.GetTopics();

        //    //Accert
        //    Assert.Null(expected);
        }
    }
}
