using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using myService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    try
                    {
                        builder
                        .AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables()
                        .Build();
                    }
                    catch { 
                    
                    }

                })
                .ConfigureServices((hostContext, services) =>
                {
                    //add your connnections, I use Postgresql you can use other database like SQL server, it should work the same.
                    // if you using Postgresql as well, you need to install Npgsql.EntityFrameworkCore.PostgreSQL in nuget.
                    try
                    {
                        services.AddDbContext<ApplicationDbContext>((IServiceProvider serviceProvider, DbContextOptionsBuilder options) =>
                            options.UseNpgsql(hostContext.Configuration.GetSection("AppConfig:ConnectionString").Value)
                        );
                    }
                    catch
                    {

                    }


                    //add your services like repositories, APIs, services.
                    services.AddScoped<ApiService>();

                    //add the worker.
                    services.AddScoped<IWorkerScope, WorkerScope>();
                    services.AddHostedService<Worker>();
                }).UseWindowsService();
        // install Microsoft.Extensions.Hosting.WindowsServices to use UseWindowsService();
    }
}
