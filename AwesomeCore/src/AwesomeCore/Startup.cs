using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

//using Swashbuckle.SwaggerGen;
using AwesomeCore.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AwesomeCore
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            this.hostingEnvironment = env;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Angular's default header name for sending the XSRF token.
            // services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
            services.AddAntiforgery(
                antiforgeryOptions =>
                {
                    antiforgeryOptions.HeaderName = "X-XSRF-TOKEN";

                    if (!hostingEnvironment.IsDevelopment())
                    {
                        // With the advent of letsencrypt.org, there is no excuse for unencrypted connections.
                        antiforgeryOptions.RequireSsl = true;
                    }
                }
            );

            // Entity Framework 7.x
            services.AddEntityFramework()
                    .AddDbContext<AwesomeContext>();

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            // Add framework services.
            services.AddMvc();

            // Swagger 2.0
            /*services.AddSwaggerGen();
            services.ConfigureSwaggerDocument(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1.0.0",
                    Title = "AwesomeCore",
                    Description = "Awesome Chat service",
                    TermsOfService = ""
                });
            });
            services.ConfigureSwaggerSchema(options =>
            {
                options.DescribeAllEnumsAsStrings = true;
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            //app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseMvc();

            //app.UseSwaggerGen();
            //app.UseSwaggerUi();

            if (env.IsDevelopment())
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<AwesomeContext>().EnsureSeedData();
                }
            }
        }
    }
}
