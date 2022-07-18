using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebMetrolog.Entity;

namespace WebMetrolog
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureServices((context, services) =>
             {
                 services.Configure<KestrelServerOptions>(
                     context.Configuration.GetSection("Kestrel"));

                 services.AddLogging(logingBuilder =>
                 {
                     logingBuilder  
                         .AddConsole();
                 });

             })

               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
                   webBuilder.UseKestrel((builderContext, options) =>
                   {
                       options.Configure(builderContext.Configuration.GetSection("Kestrel"));
                   });
               })
 
               .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace); // min уровень логгирования
                    logging.ClearProviders(); //Отключаем все логирование, кроме nlog

                    var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
                })   
                .UseNLog();
        
    }
}
