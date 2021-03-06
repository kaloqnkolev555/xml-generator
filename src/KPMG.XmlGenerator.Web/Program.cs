namespace KPMG.XmlGenerator.Web
{
    using System.IO;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using Serilog;

    /// <summary>
    /// Program class
    /// </summary>
    internal static class Program
    {
        private static string environmentName;

        /// <summary>
        /// Builds the web host.
        /// </summary>
        /// <returns></returns>
        public static IWebHost BuildWebHost() => WebHost.CreateDefaultBuilder().ConfigureLogging(
            (hostingContext, config) =>
                {
                    config.ClearProviders();
                    environmentName = hostingContext.HostingEnvironment.EnvironmentName;
                })
            .UseStartup<Startup>().Build();

        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
                var webHost = BuildWebHost();

                var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").AddJsonFile(
                        $"appsettings.{environmentName}.json",
                        optional: true,
                        reloadOnChange: true).Build();

                Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

                webHost.Run();
        }
    }
}
