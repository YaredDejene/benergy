using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Benergy.Core;
using Benergy.Core.Common;
using Benergy.Core.Mapping;
using Benergy.Modules.Subscription;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace Benergy.API
{
    public class Startup
    {
        private IModuleStartup[] modules = { new SubscriptionStartup()};
        private readonly IHostingEnvironment _hostingEnv;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            builder.AddEnvironmentVariables();   
            Configuration = builder.Build();
            _hostingEnv = env;

            // initializing all modules
            foreach (var module in this.modules)
            {
                module.Startup(Configuration);
            }

            // saving the site settgins
            SiteSettings.ConnectionString = this.Configuration.GetConnectionString("Benergy");
            SiteSettings.SendGridApiKey = this.Configuration["SendGridApiKey"];
            SiteSettings.EnvironmentName = env.EnvironmentName;
            
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Automapper configurations
            Mapper.Initialize(x =>
            {
                x.AddProfile<CoreMappingProfile>();
                foreach (var module in this.modules)
                {
                    module.ConfigureMapping(x);
                }
            });

            // configuring services for all modules
            foreach (var module in this.modules)
            {
                module.ConfigureServices(services);
            }

            services.AddMemoryCache();
            services.AddSession();

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                    options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                });

             //Compression
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Benergy API" });
            });

            services.ConfigureSwaggerGen(c =>
            {
                //Set the comments path for the swagger json and ui.                    
                c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "Benergy.API.xml"));
                c.CustomSchemaIds(x => x.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseResponseCompression();

            app.UseMvc();

            //Swagger
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
                    c.EnabledValidator(null);
                    c.BooleanValues(new object[] { 0, 1 });
                    c.DocExpansion("none");
                    c.SupportedSubmitMethods(new[] { "get", "post", "put", "delete", "patch" });
                }
            );
        }
    }
}
