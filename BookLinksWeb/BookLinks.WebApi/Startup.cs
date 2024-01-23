using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace BookLinks.Rest.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ILifetimeScope AutofacContainer { get; private set; }

        public readonly string Origins = "_Origins";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            Configuration = configuration;
        }

        //Проверить и понять нужно это или нет
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    var settings = BuildOptions();

        //    services
        //     .AddControllers(opt =>
        //     {
        //         opt.Filters.Add<UserContextActionFilter>();
        //     })
        //     .AddControllersAsServices()
        //     .AddJsonOptions(options =>
        //     {
        //         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        //     })
        //     .AddNewtonsoftJson(opt =>
        //     {
        //         opt.SerializerSettings.Converters.Add(new StringEnumConverter());
        //         opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        //     });

        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy(name: Origins,
        //              builder =>
        //              {
        //                  builder.WithOrigins(settings.AllowedOrigins)
        //                        .AllowAnyMethod()
        //                        .AllowAnyHeader()
        //                        .AllowCredentials();
        //              });
        //    });

        //    services.AddSwaggerGen(option =>
        //    {
        //        option.SwaggerDoc("v1", new OpenApiInfo { Title = "BOOKLINKS API", Version = "v1" });

        //        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //        {
        //            In = ParameterLocation.Header,
        //            Description = "Please enter a valid token",
        //            Name = "Authorization",
        //            Type = SecuritySchemeType.Http,
        //            BearerFormat = "JWT",
        //            Scheme = "Bearer"
        //        });

        //        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        //        {
        //            {
        //                new OpenApiSecurityScheme
        //                {
        //                    Reference = new OpenApiReference
        //                    {
        //                        Type=ReferenceType.SecurityScheme,
        //                        Id="Bearer"
        //                    }
        //                },
        //                new string[]{}
        //            }
        //        });
        //    });

        //    services.AddAuthentication()
        //        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
        //        {
        //            o.TokenValidationParameters = new TokenValidationParameters
        //            {
        //                ValidateIssuer = true,
        //                ValidIssuer = settings.Auth.Issuer,
        //                ValidateAudience = true,
        //                ValidAudience = settings.Auth.Audience,
        //                ValidateLifetime = true,
        //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Auth.Secret)),
        //                ValidateIssuerSigningKey = true,
        //                ClockSkew = TimeSpan.Zero
        //            };
        //            o.Events = new JwtBearerEvents
        //            {
        //                OnMessageReceived = context =>
        //                {
        //                    var accessToken = context.Request.Query["access_token"].ToString();

        //                    var path = context.HttpContext.Request.Path;
        //                    if (!string.IsNullOrEmpty(accessToken) &&
        //                        path.StartsWithSegments("/hubs/conversation"))
        //                    {
        //                        context.Token = accessToken;
        //                    }
        //                    return Task.CompletedTask;
        //                }
        //            };
        //        });

        //    services.AddSwaggerGenNewtonsoftSupport();
        //    services.AddSignalR();
        //    services.AddCors();

        //    // Add Hangfire services. Hangfire.AspNetCore nuget required
        //    services.AddHangfire(configuration => configuration
        //        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        //        .UseSimpleAssemblyNameTypeSerializer()
        //        .UseRecommendedSerializerSettings()
        //        .UseMongoStorage(settings.DbConnection.ConnectionString, settings.DbConnection.DatabaseName, new MongoStorageOptions
        //        {
        //            MigrationOptions = new MongoMigrationOptions
        //            {
        //                MigrationStrategy = new MigrateMongoMigrationStrategy(),
        //                BackupStrategy = new CollectionMongoBackupStrategy()
        //            },
        //            Prefix = "hangfire.mongo",
        //            CheckConnection = true,

        //        })
        //    );

        //    services.AddHangfireServer();
        //}

        //Проверить и понять нужно это или нет
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory,
        //    IRecurringJobManager recurringJobManager)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseRouting();
        //    app.UseCors(Origins);
        //    app.UseAuthentication();
        //    app.UseAuthorization();

        //    if (!env.IsDevelopment())
        //    {
        //        app.Use(async (context, next) =>
        //        {
        //            var path = context.Request.Path;

        //            if (path.Value.StartsWith("/swagger/", StringComparison.OrdinalIgnoreCase))
        //            {
        //                context.Response.StatusCode = 401;
        //                return;
        //            }

        //            await next();
        //        });
        //    }


        //    // enable buffering to let action filters read request body
        //    app.Use(next => context =>
        //    {
        //        context.Request.EnableBuffering();
        //        return next(context);
        //    });

        //    var settings = BuildOptions();

            //Проверить и понять нужно это или нет
            //var hfDashOptions = new DashboardOptions();

            //hfDashOptions.Authorization = new[]
            //{
            //    new HangfireAuthorizeFilter
            //    {
            //        User = settings.HangfireDashboard.Username,
            //        Pass = settings.HangfireDashboard.Password
            //    }
            //};

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //    endpoints.MapHub<TypedHub>("/hubs/conversation");

            //    endpoints.MapHangfireDashboard(hfDashOptions);
            //});

            //app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookLinks.Rest.Api v1"));

            //loggerFactory.AddSerilog();

            //AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            //Проверить и понять нужно это или нет
            //GlobalConfiguration.Configuration.UseAutofacActivator(this.AutofacContainer);

            //recurringJobManager.AddOrUpdate<IGlobalPayoutJob>("GlobalPayoutJob", x => x.RunAsync(),
            //   Cron.Daily, new RecurringJobOptions
            //   {
            //       MisfireHandling = MisfireHandlingMode.Relaxed,
            //       TimeZone = TimeZoneInfo.Utc
            //   });
            //recurringJobManager.AddOrUpdate<IGlobalTournamentPayoutJob>("GlobalTournamentPayoutJob", x => x.RunAsync(), Cron.Minutely
            //    , new RecurringJobOptions
            //    {
            //        MisfireHandling = MisfireHandlingMode.Relaxed,
            //        TimeZone = TimeZoneInfo.Utc
            //    });
        //}

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var options = BuildOptions();
            ContainerConfiguration.ResisterTypes(builder, options);
        }


        #region

        private ApiSettings BuildOptions()
        {
            return Configuration.Get<ApiSettings>();
        }

        #endregion
    }
}
