using Autofac;
using Serilog;
using Serilog.Settings.Configuration;


namespace BookLinks.Rest.Api
{
    public class ContainerConfiguration
    {
        public static void ResisterTypes(ContainerBuilder builder, ApiSettings settings)
        {
            builder.RegisterInstance(settings);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("serilog.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration,
                    new ConfigurationReaderOptions() { SectionName = "Serilog" })
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.RegisterInstance(new LoggerFactory())
                .As<ILoggerFactory>();

            builder.RegisterGeneric(typeof(Logger<>))
                   .As(typeof(ILogger<>))
                   .SingleInstance();

            //Фильтры необходимо написать свои и добавить по примеру.
            //builder.RegisterType<BgamingSignActionFilter>().AsSelf();

            //Service.ContainerConfiguration.RegisterTypes(builder, settings);

            Log.Information("ContainerConfiguration.RegisterTypes completed");
        }
    }
}
