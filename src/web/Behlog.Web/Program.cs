using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Behlog.Extensions;

namespace Behlog.Web {
    public class Program {

        public static void Main(string[] args) {
            var host = CreateHostBuilder(args)
                .Build();
            host.Services.InitializeDb();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.ConfigureLogging((hostContext, logging) => {
                        logging.ClearProviders();
                        logging.AddDebug();
                        if(hostContext.HostingEnvironment.IsDevelopment()) {
                            logging.AddConsole();
                        }
                        //logging.AddDbLogger();
                        logging.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                    }).UseStartup<Startup>();
                    webBuilder.UseDefaultServiceProvider(_ => {
                        _.ValidateScopes = false;
                    });
                });
    }
}
