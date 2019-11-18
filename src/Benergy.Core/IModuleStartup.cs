using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Benergy.Core
{
    /// <summary>
    ///  Interface to specify available StartUp methods
    /// </summary>
    public interface IModuleStartup
    {
        void Startup(IConfigurationRoot configuration);

        void ConfigureServices(IServiceCollection services);

        void ConfigureDependencyInjection(IServiceCollection services);

        void ConfigureMapping(IMapperConfigurationExpression action);

        void Configure(IApplicationBuilder app, IHostingEnvironment env);
    }
}