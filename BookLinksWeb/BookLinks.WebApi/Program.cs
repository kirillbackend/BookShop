using Autofac.Extensions.DependencyInjection;
using Autofac;
using Serilog;

namespace BookLinks.Rest.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webHostBuilder => {
                    webHostBuilder
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>();
                })
                .Build();

            host.Run();

            //var host = Host.CreateDefaultBuilder(args)
            //      .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            //      .ConfigureContainer<ContainerBuilder>((context, builder) =>
            //      {

            //      })
            //      .ConfigureAppConfiguration((hostingContext, config) =>
            //      {
            //          var env = hostingContext.HostingEnvironment;
            //          config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            //                .AddEnvironmentVariables("LDBR_");
            //      })
            //      .ConfigureWebHostDefaults(webHostBuilder =>
            //      {
            //          webHostBuilder
            //           .UseContentRoot(Directory.GetCurrentDirectory())
            //           .UseIISIntegration()
            //           .UseStartup<Startup>();
            //      })
            //      .UseSerilog((hostContext, services, configuration) =>
            //      {
            //          configuration.WriteTo.Console();
            //      })
            //      .Build();
        }
    }
}