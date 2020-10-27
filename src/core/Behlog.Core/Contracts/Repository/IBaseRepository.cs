using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Behlog.Core.Contracts.Repository {
    public interface IBaseRepository<TEntity, TKey> where TEntity : class {

        Task AddAndSaveAsync(TEntity newEntity);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> ExecuteSqlCommandAsync(string query, params object[] parameters);

        TEntity Find(TKey id);

        Task<TEntity> FindAsync(TKey id);

        void MarkForAdd(TEntity entity);

        void MarkForUpdate(TEntity entity);

        void SaveChanges();

        Task SaveChangesAsync();

        IQueryable<TEntity> Query();

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task UpdateAndSaveAsync(TEntity entity);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}

