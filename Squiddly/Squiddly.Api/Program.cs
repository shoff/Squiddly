namespace Squiddly.Api
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;
    using Serilog.Events;

    [ExcludeFromCodeCoverage]
    public class Program
    {
        internal static string HostingEnvironment =>
            Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process) ??
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process);

        public static void Main(string[] args)
        {
            var serilogConfiguration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{HostingEnvironment}.json", true, true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .ReadFrom.Configuration(serilogConfiguration)
                .CreateLogger();

            try
            {
                var host = CreateWebHostBuilder(args);
#if DEBUG
                using (var scope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    //SeedData.EnsureSeedData(scope.ServiceProvider);
                    // return;
                }
#endif
                host.Run();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, e.Message);
                throw;
            }
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {

            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", false, true);
                    config.AddJsonFile($"appsettings.{HostingEnvironment}.json", true, true);
                    config.AddJsonFile("secrets.json", false, true);
                    config.AddJsonFile($"secrets.{HostingEnvironment}.json", true, true);
                })
                .UseStartup<Startup>()
                .UseSerilog()
                .UseKestrel()
                .UseIISIntegration()
                .Build();

        }
    }
}
