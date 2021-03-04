using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FPTCertification.WebApi.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FPTCertification.WebApi
{
#pragma warning disable CS1591
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
            {
                var assembly = Assembly.GetAssembly(typeof(Program));
                var pathToConfig = Path.Combine(
                          hostingContext.HostingEnvironment.ContentRootPath
                        , "log4net.config");
                var logManager = new AppLogManager(pathToConfig, assembly);

                logging.AddLog4Net(new Log4NetProviderOptions
                {
                    ExternalConfigurationSetup = true
                });
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
#pragma warning restore CS1591
}
