namespace KPMG.XmlGenerator.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Security.Claims;

    using AutoMapper;

    using FluentValidation.AspNetCore;
    using KPMG.XmlGenerator.Business;
    using KPMG.XmlGenerator.Core;
    using KPMG.XmlGenerator.Data;
    using KPMG.XmlGenerator.Data.Commands;
    using KPMG.XmlGenerator.Data.Queries;
    using KPMG.XmlGenerator.Data.Repository;
    using KPMG.XmlGenerator.Web.AutoMapperConfiguraton;
    using KPMG.XmlGenerator.Web.Configuration;
    using KPMG.XmlGenerator.Web.Exception;
    using KPMG.XmlGenerator.Web.Security;
    using KPMG.XmlGenerator.Web.ServiceConfiguration;

    using MediatR;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Serilog;

    using Swashbuckle.AspNetCore.Swagger;

    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        public Startup(IHostingEnvironment env)
        {
            IConfigurationBuilder builder;

            if (env.IsDevelopment())
            {
                builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.Development.json", false, true).AddEnvironmentVariables();

                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                    .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();
            }
            else
            {
                builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", false, true).AddEnvironmentVariables();
            }

            this.Configuration = builder.Build();
            this.CurrentEnvironment = env;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Gets the current environment.
        /// </summary>
        /// <value>
        /// The current environment.
        /// </value>
        private IHostingEnvironment CurrentEnvironment { get; }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="scopeFactory">The scope factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceScopeFactory scopeFactory)
        {
            Log.Information($"Starting {env.ApplicationName} in {env.EnvironmentName}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.d
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "XML Generator");
                //c.RoutePrefix = string.Empty;
            });

            app.UseKPMGSecurity(this.Configuration);
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseSession();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseMvc(routes => { routes.MapRoute(name: "default", template: "{controller}/{action=Index}/{id?}"); });
            app.UseSpa(
                spa =>
                    {
                        // To learn more about options for serving an Angular SPA from ASP.NET Core,
                        // see https://go.microsoft.com/fwlink/?linkid=864501
                        spa.Options.SourcePath = "ClientApp";
                        var serviceFabricHostMarker = Environment.GetEnvironmentVariable("ServiceFabricHostMarker");

                        if (env.IsDevelopment() && serviceFabricHostMarker == null)
                        {
#if debugDev
                            spa.UseAngularCliServer(npmScript: "start-dev_vs");
#else
                            spa.UseAngularCliServer(npmScript: "start");
#endif
                        }
                    });
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddMemoryCache();

            if (this.CurrentEnvironment.EnvironmentName != "IntegrationTest")
            {
                // Handle multiple connection strings
                services.AddSingleton<IDictionary<string, DbConnectionAppSettingsConfiguration>>(
                    Configuration.GetSection("ConfiguredDbConnections").Get<DbConnectionAppSettingsConfiguration[]>().ToDictionary(x => x.Name.ToLowerInvariant(), x => x));

                services.AddScoped<DbConnectionsConfigurationService>();

                services.AddDbContext<XmlGeneratorDbContext>(
                    (serviceProvider, options) =>
                    {
                        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                        var dbConnectionAppSettingsConfiguration = serviceProvider.GetService<IDictionary<string, DbConnectionAppSettingsConfiguration>>();

                        var dbConnection = this.GetConnectionString(httpContext, dbConnectionAppSettingsConfiguration);

                        if (!string.IsNullOrEmpty(dbConnection))
                        {
                            options.UseSqlServer(dbConnection);
                        }
                    });
            }
            else
            {
                services.AddDbContext<XmlGeneratorDbContext>(options => options.UseInMemoryDatabase("IntegrationDb"));
            }

            services.AddScoped<DbContext, XmlGeneratorDbContext>();
            //services.AddDbContext<XmlGeneratorDbContext>(options => options.UseSqlServer("EfDb"));
            // services.Add(ServiceDescriptor.Scoped(typeof(ICommandRepository<,>), typeof(EfCoreCommandRepository<,>)));
            // services.Add(ServiceDescriptor.Scoped(typeof(IQueryRepository<,>), typeof(EfCoreQueryRepository<,>)));

            // FluentValidation services
            services.RegisterValidationServiceExtension();

            // Repository pattern services
            services.AddTransient<IQueryRepository, Repository>();
            services.AddTransient<ICommandRepository, Repository>();

            // CQRS services
            services.AddScoped(typeof(ICommandHandler<>), typeof(CommandHandler<>));
            services.AddScoped(typeof(IQueryHandler<>), typeof(QueryHandler<>));

            // Business services
            services.RegisterBusinessServiceExtension();

            // MediatR
            services.AddMediatR(typeof(DbSqlScriptsHandler).GetTypeInfo().Assembly);


            // Other
            services.AddTransient<IClaimsTransformation, UserClaimsTransformer>();
            services.AddKPMGSecurity(this.Configuration);
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(300);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddCors();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "XML Generator", Version = "v1" });
            });

            // add FluentValidation
            services.AddMvc(config => {
                    config.Filters.Add(typeof(GlobalExceptionFilter));
                    config.Filters.Add(typeof(CustomJSONExceptionFilter));
                    config.Filters.Add(new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None });
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                       policy.RequireClaim(ClaimTypes.Role, "Admin"));

                options.AddPolicy("User", policy =>
                       policy.RequireClaim(ClaimTypes.Role, "User"));
            });

            services.AddAutoMapper(new Assembly[]
            {
                typeof(AutoMapperProfileConfiguration).GetTypeInfo().Assembly
            }
            );

            if (this.Configuration.GetSection("ApplicationInsights:Enabled").Get<bool>())
            {
                services.AddApplicationInsightsTelemetry();
            }

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        private string GetConnectionString(HttpContext httpContext, IDictionary<string, DbConnectionAppSettingsConfiguration> dbConnectionAppSettingsConfiguration)
        {
            //const string xmlGeneratorSessionKey = "XmlGeneratorDatabaseName";

            //if (httpContext.Session.IsAvailable && httpContext.Session.Keys.Any(k => k.Equals(xmlGeneratorSessionKey)))
            //{
            //    var conn = Configuration.GetSection("DbConnection:ConnectionString").Get<string>();
            //    var dbName = httpContext.Session.GetString(xmlGeneratorSessionKey);
            //    return conn.Replace("{dbName}", dbName);
            //}

            //var conn = Configuration.GetSection("DbConnection:ConnectionString").Get<string>();
            //return conn.Replace("{dbName}", "_META_XML_GENERATOR_PROD_GENERIC");

            var requestedDb = httpContext.Request.Query["DB"].FirstOrDefault();
            DbConnectionAppSettingsConfiguration db;
            if (requestedDb == null || !dbConnectionAppSettingsConfiguration.TryGetValue(requestedDb.ToLowerInvariant(), out db) || !db.IsActive)
            {
                db = dbConnectionAppSettingsConfiguration.Values.Where(c => c.IsActive).OrderByDescending(c => c.IsDefault).First();
            }

            return db.ConnectionString;
        }
    }
}
