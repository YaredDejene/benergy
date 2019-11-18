using Benergy.Core.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Benergy.Core
{
    /// <summary>
    /// This is base startup class. This initializes the database connection and provide abstract methods
    /// </summary>
    public abstract class ModuleStartup<TContext> : IModuleStartup
        where TContext : DbContext
    {
        protected IConfigurationRoot Configuration { get; set; }

        public virtual void Startup(IConfigurationRoot configuration)
        {
            this.Configuration = configuration;
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
            .AddDbContext<TContext>(options =>
            {
                options.UseNpgsql(SiteSettings.ConnectionString);
            });

            this.ConfigureDependencyInjection(services);
        }

        public abstract void ConfigureDependencyInjection(IServiceCollection services);

        public void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.AddProfiles(this.GetType().Assembly);
        }

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // this is not required for all Modules. Those needed will override
        }
    }
}