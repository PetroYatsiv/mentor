using ForumClientApp.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumClientApp
{
    public static class ServiceHttpClientsExtensions
    {
        readonly static string url = "https://localhost:44310/";

        public static void ConfigureHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient(Clients.TopicClient, client => { client.BaseAddress = new Uri(url); });
            services.AddHttpClient(Clients.SectionClient, client => { client.BaseAddress = new Uri(url); });
        }
    }
}
