using Benergy.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Benergy.Modules.Subscription.Entities;

namespace Benergy.Modules.Subscription.Repositories
{
    /// <summary>
    /// EF DB Context for Subscription Module
    /// </summary>
    public class SubscriptionDbContext: BaseDbContext<SubscriptionDbContext>
    {
        public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<PlanEntity> Plans { get; set; }

        public DbSet<StatusEntity> Statuses { get; set; }

        public DbSet<UserSubscriptionEntity> UserSubscriptions { get; set; }
        
    }
}