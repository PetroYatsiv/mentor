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
    }

    public class SectionService : ISectionService
    {
        HttpClient client;
        string url = "https://localhost:44310/";

        public SectionService()
        {           
        }

        public List<Section> GetSections()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var section = new List<Section>();
            HttpResponseMessage responseMessage = client.GetAsync("api/Section").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var test = JsonConvert.DeserializeObject<List<Section>>(responseData);
                return test;
            }
                return section;
        }
    }
}
