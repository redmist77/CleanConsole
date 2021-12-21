using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(AppSettings.BasePath);
            using var host = CreateDefaultHost(args).Build();
            var service = ActivatorUtilities.CreateInstance<Startup>(host.Services);
            service.Run();
        }

        static IHostBuilder CreateDefaultHost(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(AppSettings.BasePath);
                })
                .ConfigureLogging((hostingContext, builder) =>
                {
                    builder.AddFile(AppSettings.LogFile);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddOptions<AppSettings>()
                        .Bind(context.Configuration.GetSection(AppSettings.Settings));
                });
    }
}
