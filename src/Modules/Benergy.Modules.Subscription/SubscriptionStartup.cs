using System;
using Benergy.Core;
using Benergy.Modules.Subscription.Domain;
using Benergy.Modules.Subscription.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Benergy.Modules.Subscription
{
    /// <summary>
    /// Startup for Subscription module
    /// </summary>
    public class SubscriptionStartup: ModuleStartup<SubscriptionDbContext>
    {
        public override void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<SubscriptionDomain>();
            services.AddTransient<SubscriptionRepository>();
        }
    }
}
