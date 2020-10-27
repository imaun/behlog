using System;
using System.Linq;
using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository;
using System.Linq.Expressions;
using Behlog.Core.Contracts;
using Behlog.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Behlog.Repository {

    public abstract class BaseRepository<TEntity, TKey> 
        : IBaseRepository<TEntity, TKey> where TEntity : class 
    {

        protected readonly IBehlogContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(IBehlogContext context) {
            context.CheckArgumentIsNull();
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task AddAndSaveAsync(TEntity newEntity) {
            await _dbSet.AddAsync(newEntity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) 
            => await _dbSet.AnyAsync(predicate);
        

        public virtual async Task<int> ExecuteSqlCommandAsync(
            string query, params object[] parameters) 
            => await _context.ExecuteSqlCommandAsync(query, parameters);
        

        public virtual TEntity Find(TKey id) {
            return _dbSet.Find(id);
        }

        public virtual async Task<TEntity> FindAsync(TKey id) {
            return await _dbSet.FindAsync(id);
        }

        public virtual void MarkForAdd(TEntity entity) {
            _dbSet.Add(entity);
        }

        public virtual void MarkForUpdate(TEntity entity) {
            _dbSet.Update(entity);
        }

        public virtual void SaveChanges() {
            _context.SaveChanges();
        }

        public virtual async Task SaveChangesAsync() {
            await _context.SaveChangesAsync();
        }

        public virtual IQueryable<TEntity> Query() {
            return _dbSet.AsNoTracking();
        }

        public virtual TEntity SingleOrDefault(
            Expression<Func<TEntity, bool>> predicate) => _dbSet.SingleOrDefault(predicate);
        

        public virtual async Task<TEntity> SingleOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate) => await _dbSet.SingleOrDefaultAsync(predicate);

        public virtual async Task<TEntity> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate) => await _dbSet.FirstOrDefaultAsync(predicate);

        public virtual async Task UpdateAndSaveAsync(TEntity entity) {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

}
