using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataForum;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                
            }
                CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
// for Reverse Engineering or (Database first)
// tools -> NuGet Package Manager -> Package Manager Console
// don`t forget choose default project in Package Manager console
// Scaffold-DbContext "Server=WS-LV-CP2922\SQLEXPRESS;Database=forumDatabase;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
