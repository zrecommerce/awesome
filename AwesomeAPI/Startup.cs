using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen;
using AwesomeAPI.Models;

namespace AwesomeAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
                    Version = "v1",
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
