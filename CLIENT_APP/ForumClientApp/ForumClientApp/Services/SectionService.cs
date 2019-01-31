using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ForumClientApp.Models;
using Newtonsoft.Json;
using Forum.Data.Models;

namespace ForumClientApp.Services
{
    public interface ISectionService
    {
        List<SectionViewModel> GetSections();
       List<SectionViewModel> CreateNewSection(SectionViewModel sectionViewModel);
    }

    public class ServiceBase
    {
        protected readonly HttpClient _httpClient;

        protected ServiceBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
    public class SectionService : ServiceBase, IService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        //public SectionService(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        public SectionService(HttpClient clientName): base(clientName)
        {
        }

        public async Task<List<SectionViewModel>> GetSectionsAsync()
        {
            var client = _httpClientFactory.CreateClient("SectionClient");
            var responseMessage = await client.GetAsync("api/Section");

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var sections = JsonConvert.DeserializeObject<List<SectionViewModel>>(responseData);
                return sections;
            }
            return new List<SectionViewModel>();
        }

        public List<SectionViewModel> CreateNewSection(SectionViewModel section)
        {
            Section postSection = new Section();

            postSection.SectionDescription = section.SectionDescription;

            var client = _httpClientFactory.CreateClient("SectionClient");
            string stringData = JsonConvert.SerializeObject(postSection);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            try
            {
                response = client.PostAsync("api/Section", contentData).Result;
            }
            catch (Exception ex)
            {
                var postException = ex.Message;
            }

            string content = response.Content.ReadAsStringAsync().ToString();

            return new List<SectionViewModel>();
        }



        public void UpdateSection(int sectionId, SectionViewModel section)
        {

        }

        public void DeleteSection (int sectionId)
        {

        }
    }
}
