using ForumClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForumClientApp.Services
{
    public class ServiceBase
    {
        protected readonly HttpClient _client;
        protected readonly IHttpClientFactory _httpClientFactory;

        public ServiceBase(IHttpClientFactory httpClientFactory, string clients)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient(clients);
        }
    }
}
