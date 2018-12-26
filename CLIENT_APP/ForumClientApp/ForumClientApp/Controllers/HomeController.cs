using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumClientApp.Models;
using Forum.Data.Models;
using WebApplication1.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ForumClientApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var test = new List<string>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44310/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Values/");
                
                if (Res.IsSuccessStatusCode)
                {
                    var responce = Res.Content.ReadAsStringAsync().Result;
                    test = JsonConvert.DeserializeObject<List<string>>(responce);
                }
            }
            return View(test);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
