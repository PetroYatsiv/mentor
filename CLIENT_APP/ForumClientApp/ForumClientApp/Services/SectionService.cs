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
        List<Section> GetSections();
        bool CreateNewSection();
    }

    public class SectionService : ISectionService
    {
        static HttpClient client;
        string url = "https://localhost:44310/";
        string responceData;
        HttpResponseMessage responseMessage;

        public SectionService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            responseMessage = client.GetAsync("api/Section").Result;
        }

        public bool CreateNewSection()
        {
            return true;
        }

        static async Task<Uri> CreateSectionAsync(Section section)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Section", section);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public List<Section> GetSections()
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var test = JsonConvert.DeserializeObject<List<Section>>(responseData);
                return test;
            }
            return new List<Section>();
        }
    }
}
