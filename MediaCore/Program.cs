﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WalkingTec.Mvvm.Core;

namespace MediaCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            return
                Host.CreateDefaultBuilder(args)
                  .ConfigureAppConfiguration((hostingContext, config) =>
                  {
                      config.AddInMemoryCollection(new Dictionary<string, string> {
                          { "HostRoot", hostingContext.HostingEnvironment.ContentRootPath }
                      });
                  })
                 .ConfigureLogging((hostingContext, logging) =>
                 {
                     logging.ClearProviders();
                     logging.AddConsole();
                     logging.AddWTMLogger();
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                     webBuilder.UseWebRoot("wwwroot").UseStaticWebAssets();
                     webBuilder.ConfigureAppConfiguration((webContext, config) =>
                     {
                         config.AddInMemoryCollection(new Dictionary<string, string> {
                             { "WebRoot", webContext.HostingEnvironment.WebRootPath }
                         });
                     });
                 });
        }
    }
}
