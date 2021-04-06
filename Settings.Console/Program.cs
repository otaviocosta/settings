using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Settings.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            await printSettings(host.Services);
        }

        private static Task printSettings(IServiceProvider services)
        {
            var configuration = (IConfiguration)services.GetService(typeof(IConfiguration));
            var switchMappings = new Dictionary<string, string>()
                                     {
                                         { "myKeyValue", configuration["MyKey"] },
                                         { "nivel1", configuration["Variaveis:Nivel1"] },
                                         { "nivel2", configuration["Variaveis:Nivel2"] },
                                         { "nivel3", configuration["Variaveis:Nivel3"] },
                                         { "nivel4", configuration["Variaveis:Nivel4"] },
                                         { "nivel5", configuration["Variaveis:Nivel5"] },
                                         { "nivel6", configuration["Variaveis:Nivel6"] },
                                     };

            foreach (var item in switchMappings)
            {
                System.Console.WriteLine($"{item.Key} - {item.Value}");

            }
            return Task.CompletedTask;

        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, configuration) =>
            {
                configuration.Sources.Clear();

                IHostEnvironment env = hostingContext.HostingEnvironment;

                configuration
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                    .AddUserSecrets<Program>()
                    .AddEnvironmentVariables()
                    .AddCommandLine(args);

                IConfigurationRoot configurationRoot = configuration.Build();

            })
            ;

    }
}
