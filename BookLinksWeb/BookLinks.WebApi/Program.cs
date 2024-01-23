using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;

namespace BookLinks.Rest.Api
{
    //Проверить и понять нужно это или нет
    internal class Program
    {
        private static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
               .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                  .ConfigureContainer<ContainerBuilder>((context, builder) =>
                  {

                  })
                  .ConfigureAppConfiguration((hostingContext, config) =>
                  {
                      var env = hostingContext.HostingEnvironment;
                      config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                            .AddEnvironmentVariables("BookLinks_");
                  })
                  .ConfigureWebHostDefaults(webHostBuilder =>
                  {
                      webHostBuilder
                       .UseContentRoot(Directory.GetCurrentDirectory())
                      .UseIISIntegration()
                       .UseStartup<Startup>();
                  })
                  .UseSerilog((hostContext, services, configuration) =>
                  {
                      configuration.WriteTo.Console();
                  })
                  .Build();

            host.Run();
        }
    }
}