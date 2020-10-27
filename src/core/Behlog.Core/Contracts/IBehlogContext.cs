using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Behlog.Core.Contracts {
    public interface IBehlogContext: IDisposable {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class;
        int ExecuteSqlCommand(string query);
        Task<int> ExecuteSqlCommandAsync(string query, params object[] parameters);
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void SetAsNoTrackingQuery();
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        void ExecuteSqlInterpolatedCommand(FormattableString query);
        void ExecuteSqlRawCommand(string query, params object[] parameters);
    }
}
