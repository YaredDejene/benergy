using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Benergy.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Benergy.Core.Repositories
{
    public class BaseDbContext<TContext> : DbContext
        where TContext : DbContext
    {
        public BaseDbContext(DbContextOptions<TContext> options)
            : base(options)
        {
        }

        public virtual IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters)
            where TEntity : class
        {
            return this.Set<TEntity>().FromSql(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await this.Database.ExecuteSqlCommandAsync(sql, default(CancellationToken), parameters);
        }

        protected void IgnoreAuditFields<TEntity>(ModelBuilder builder)
            where TEntity : BaseEntity
        {
            builder.Entity<TEntity>(e =>
            {
                e.Ignore(p => p.CreatedDate);
                e.Ignore(p => p.CreatedUserID);
                e.Ignore(p => p.LastModifiedUserID);
            });
        }
    }
}