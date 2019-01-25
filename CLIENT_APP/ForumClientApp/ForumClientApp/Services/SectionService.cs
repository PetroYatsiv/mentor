using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ForumClientApp.Models;
using Newtonsoft.Json;

namespace ForumClientApp.Services
{
    public interface ISectionService
    {
        List<SectionViewModel> GetSections();
       
    }

    public class SectionService : ISectionService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SectionService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public SectionService()
        {
        }

        public List<SectionViewModel> GetSections()
        {
            var client = _httpClientFactory.CreateClient("SectionClient");
            var responseMessage = client.GetAsync("api/Section").Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var sections = JsonConvert.DeserializeObject<List<SectionViewModel>>(responseData);
                return sections;
            }
            return new List<SectionViewModel>();
        }

        //public List<SectionViewModel> CreateNewSection(SectionViewModel section)
        //{
        //    var client = _httpClientFactory.CreateClient("SectionClient");
        //    string stringData = JsonConvert.SerializeObject(section);
        //    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = client.PostAsync("", contentData).Result;
        //    var result = response.Content;
        //    var sections
        //}
    }
}
