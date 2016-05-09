using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Antiforgery;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen;
using AwesomeAPI.Models;
using Microsoft.AspNet.Http.Features;

namespace AwesomeAPI
{
    public class Startup
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            
            this.hostingEnvironment = env;
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Angular's default header name for sending the XSRF token.
            // services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
            services.ConfigureAntiforgery(
                antiforgeryOptions => 
                {
                    if (!hostingEnvironment.IsDevelopment())
                    {
                        // With the advent of letsencrypt.org, there is no excuse for unencrypted connections.
                        antiforgeryOptions.RequireSsl = true;
                    }
                }
            );
            
            // Entity Framework 7.x
            services.AddEntityFramework()
                    .AddSqlite()
                    .AddDbContext<AwesomeContext>();
            
            // Add framework services.
            services.AddMvc();
            
            // Swagger 2.0
            services.AddSwaggerGen();
            services.ConfigureSwaggerDocument(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1.0.0",
                    Title = "AwesomeAPI",
                    Description = "Awesome Chat service",
                    TermsOfService = ""   
                });
            });
            services.ConfigureSwaggerSchema( options =>
            {
                options.DescribeAllEnumsAsStrings = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseStaticFiles();
            
            app.UseMvc();
            
            // app.Use(async(context, next) => {
            //     var request = context.Features[typeof(IHttpRequestFeature)] as IHttpRequestFeature;
                
            //     var cookieToken = request.Headers["Cookie"];
            //     var formToken = request.Headers["__RequestVerificationToken"];
                
            //     if (!StringValues.IsNullOrEmpty(cookieToken) && !StringValues.IsNullOrEmpty(formToken))
            //     {
                    
            //     }
            //     await next.Invoke();
            // });
            
            app.UseSwaggerGen();
            app.UseSwaggerUi();
            
            if (env.IsDevelopment())
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<AwesomeContext>().EnsureSeedData();
                }
            }
            
        }
        
        
        

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}
