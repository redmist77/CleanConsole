using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsoleApp
{
    class Startup
    {
        public Startup(
            IConfiguration configuration,
            ILogger<Startup> logger,
            IOptions<AppSettings> settings)
        {
            Configuration = configuration;
            Logger = logger;
            Settings = settings;
        }

        IConfiguration Configuration { get; }

        ILogger<Startup> Logger { get; }

        IOptions<AppSettings> Settings { get; }

        public void Run()
        {
            Logger.LogInformation("{Greeting}", Settings.Value.Greeting);
            Logger.LogInformation("{Configuration}", Configuration["arg1"]); // e.g. ConsoleApp.exe --arg1 "Hello World!"
            Logger.LogInformation("{Configuration}", Configuration["LOCALAPPDATA"]);
        }
    }
}
