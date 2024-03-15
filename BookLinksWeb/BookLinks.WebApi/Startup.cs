using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hangfire;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace BookLinks.Rest.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public readonly string Origins = "_Origins";

        public IConfiguration Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
        {
            _webHostEnvironment = webHostEnvironment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var settings = BuildOptions();

            services
              .AddControllers(opt =>
              {
                  // необходимо разобратся с фильтрами и написать собственный по примеру.
                  //opt.Filters.Add<UserContextActionFilter>();
              })
              .AddControllersAsServices()
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
              })
              .AddNewtonsoftJson(opt =>
              {
                  opt.SerializerSettings.Converters.Add(new StringEnumConverter());
                  opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
              });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: Origins,
            //          builder =>
            //          {
            //              builder.WithOrigins(settings.AllowedOrigins)
            //                    .AllowAnyMethod()
            //                    .AllowAnyHeader()
            //                    .AllowCredentials();
            //          });
            //});

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "LDBR API", Version = "v1" });

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddAuthentication();

            // разобратся что это
            //.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
            //{
            //    o.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidIssuer = settings.Auth.Issuer,
            //        ValidateAudience = true,
            //        ValidAudience = settings.Auth.Audience,
            //        ValidateLifetime = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Auth.Secret)),
            //        ValidateIssuerSigningKey = true,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //    o.Events = new JwtBearerEvents
            //    {
            //        OnMessageReceived = context =>
            //        {
            //            var accessToken = context.Request.Query["access_token"].ToString();

            //            var path = context.HttpContext.Request.Path;
            //            if (!string.IsNullOrEmpty(accessToken) &&
            //                path.StartsWithSegments("/hubs/conversation"))
            //            {
            //                context.Token = accessToken;
            //            }
            //            return Task.CompletedTask;
            //        }
            //    };
            //});

            //services.AddSwaggerGenNewtonsoftSupport();
            //var hasRedis = !string.IsNullOrEmpty(settings.DbConnection.RedisAddress);

            //if (!hasRedis || !settings.UseRedisSignalR)
            //{
            //    Console.WriteLine("Redis address is empty. Redis connection will not proceed");
            //    services.AddSignalR();
            //}
            //else
            //{
            //    Console.WriteLine("Found Redis address in settings, trying to connect");
            //    services.AddSignalR()
            //        .AddStackExchangeRedis(options =>
            //        {
            //            options.ConnectionFactory = async writer =>
            //            {
            //                var config = new ConfigurationOptions
            //                {
            //                    AbortOnConnectFail = false
            //                };
            //                config.EndPoints.Add(settings.DbConnection.RedisAddress, 6379);
            //                config.User = settings.DbConnection.RedisUser;
            //                config.Password = settings.DbConnection.RedisPassword;

            //                var connection = await ConnectionMultiplexer.ConnectAsync(config, writer);
            //                connection.ConnectionFailed += (_, e) =>
            //                {
            //                    Console.WriteLine("Connection to Redis failed.");
            //                };

            //                if (!connection.IsConnected)
            //                {
            //                    Console.WriteLine("Did not connect to Redis.");
            //                }

            //                if (connection.IsConnected)
            //                {
            //                    Console.WriteLine("Successfully connected to Redis");
            //                }

            //                return connection;
            //            };
            //        });
            //}

            services.AddCors();


            // Add Hangfire services. Hangfire.AspNetCore nuget required
            //services.AddHangfire(configuration =>
            //{
            //    configuration
            //        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            //        .UseSimpleAssemblyNameTypeSerializer()
            //        .UseRecommendedSerializerSettings();

            //    if (hasRedis && settings.Hangfire.UseRedis)
            //    {
            //        var redisConfig = new ConfigurationOptions
            //        {
            //            AbortOnConnectFail = false
            //        };
            //        redisConfig.EndPoints.Add(settings.DbConnection.RedisAddress, 6379);
            //        redisConfig.User = settings.DbConnection.RedisUser;
            //        redisConfig.Password = settings.DbConnection.RedisPassword;
            //        configuration.UseRedisStorage(ConnectionMultiplexer.Connect(redisConfig));
            //    }
            //    else
            //    {
            //        configuration.UseMongoStorage(settings.DbConnection.ConnectionString, settings.DbConnection.DatabaseName, new MongoStorageOptions
            //        {
            //            MigrationOptions = new MongoMigrationOptions
            //            {
            //                MigrationStrategy = new MigrateMongoMigrationStrategy(),
            //                BackupStrategy = new CollectionMongoBackupStrategy()
            //            },
            //            Prefix = settings.Hangfire.TablePrefix,
            //            CheckConnection = true,
            //        });
            //    }
            //});

            //services.AddHangfireServer(x =>
            //{
            //    x.SchedulePollingInterval = TimeSpan.FromSeconds(settings.Hangfire.PoolingSeconds);
            //    x.WorkerCount = Environment.ProcessorCount * settings.Hangfire.WorkerMuliplier;
            //    x.Queues = new[] { "alpha", "beta", "default" };
            //});

            //if (settings.CmsSettings.CacheSeconds > 0)
            //{
            //    services.AddMemoryCache();
            //}
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
            //,IRecurringJobManager recurringJobManager)
        {
            if (env.IsDevelopment())
            {
                Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(Origins);
            app.UseAuthentication();
            app.UseAuthorization();

            if (!env.IsDevelopment())
            {
                app.Use(async (context, next) =>
                {
                    var path = context.Request.Path;

                    if (path.Value.StartsWith("/swagger/", StringComparison.OrdinalIgnoreCase))
                    {
                        context.Response.StatusCode = 401;
                        return;
                    }

                    await next();
                });
            }


            // enable buffering to let action filters read request body
            app.Use(next => context =>
            {
                context.Request.EnableBuffering();
                return next(context);
            });

            var settings = BuildOptions();
            var hfDashOptions = new DashboardOptions();


            // Настроить HangfireAuthorizeFilter
            //hfDashOptions.Authorization = new[]
            //{
            //    new HangfireAuthorizeFilter
            //    {
            //        User = settings.Hangfire.DashboardUsername,
            //        Pass = settings.Hangfire.DashboardPassword
            //    }
            //};

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // узнать что это и определить нужно это или нет
                //endpoints.MapHub<TypedHub>("/hubs/conversation");

                //endpoints.MapHangfireDashboard(hfDashOptions);
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookLinks.Rest.Api v1"));

            loggerFactory.AddSerilog();

            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            GlobalConfiguration.Configuration.UseAutofacActivator(this.AutofacContainer);

            // разобратся как работают джобы и сделать свои по примеру
            //recurringJobManager.AddOrUpdate<IGlobalPayoutJob>("GlobalPayoutJob", x => x.RunAsync(),
            //   Cron.Daily, new RecurringJobOptions
            //   {
            //       MisfireHandling = MisfireHandlingMode.Relaxed,
            //       TimeZone = TimeZoneInfo.Utc
            //   });

            //recurringJobManager.AddOrUpdate<IGlobalTournamentPayoutJob>("GlobalTournamentPayoutJob",
            //    x => x.RunAsync(),
            //    Cron.Minutely,
            //    new RecurringJobOptions
            //    {
            //        MisfireHandling = MisfireHandlingMode.Relaxed,
            //        TimeZone = TimeZoneInfo.Utc,
            //    });

            //recurringJobManager.AddOrUpdate<IGlobalDominoJob>("GlobalDominoJobCheckSubscriptions", x => x.CheckSubscriptions(),
            //   Cron.Daily, new RecurringJobOptions
            //   {
            //       MisfireHandling = MisfireHandlingMode.Relaxed,
            //       TimeZone = TimeZoneInfo.Utc
            //   });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var options = BuildOptions();
            ContainerConfiguration.ResisterTypes(builder, options);
        }

        #region private metods

        private ApiSettings BuildOptions()
        {
            return Configuration.Get<ApiSettings>();
        }

        #endregion
    }
}
