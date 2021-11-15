using FreeCourse.Services.Catalog.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var categoryServices = serviceProvider.GetRequiredService<ICategoryService>();
                if (!categoryServices.GetAllAsync().Result.Data.Any())
                {
                    categoryServices.CreateAsync(new Dtos.CategoryCreateDto { Name = "Asp.net Core Kursu1" }).Wait();
                    categoryServices.CreateAsync(new Dtos.CategoryCreateDto { Name = "Asp.net Core Kursu2" }).Wait();
                    categoryServices.CreateAsync(new Dtos.CategoryCreateDto { Name = "Asp.net Core Kursu3" }).Wait();
                }
                
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
