using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Benergy.Core.Repositories;
using Benergy.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Benergy.Test
{
    public class BaseTest
    {
        protected IServiceCollection ServiceCollection { get; set; }

        protected NTContextModel AppContext
        {
            get
            {
                return NTContext.Context;
            }
        }

        protected void CreateAppContext()
        {
            NTContext.Context = new NTContextModel() { UserName = "mailtoyared@gmail.com" };
        }

        protected TContext CreateDbContext<TContext>()
            where TContext : DbContext
        {
            this.ServiceCollection = new ServiceCollection();
            IServiceProvider serviceProvider = this.ServiceCollection
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<TContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            var mockContext = new Mock<TContext>(builder.Options) { CallBase = true };
            return mockContext.Object;
        }

        protected async Task SaveChangesAsync(params DbContext[] dbContexts)
        {
            foreach (DbContext context in dbContexts)
            {
                await context.SaveChangesAsync();
                var entries = context.ChangeTracker.Entries().ToList();
                foreach (var entry in entries)
                {
                    entry.State = EntityState.Detached;
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
