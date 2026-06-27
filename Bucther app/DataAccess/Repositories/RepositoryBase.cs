using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Bucther_app.DataAccess.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DatabaseContext _context;

        protected RepositoryBase(DatabaseContext context)
        {
            _context = context;
        }

        // Абстрактные методы для конкретных таблиц
        protected abstract string GetByIdQuery { get; }
        protected abstract string GetAllQuery { get; }
        protected abstract string InsertQuery { get; }
        protected abstract string UpdateQuery { get; }
        protected abstract string DeleteQuery { get; }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _context.QueryFirstOrDefaultAsync<TEntity>(GetByIdQuery, new { Id = id });
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.QueryAsync<TEntity>(GetAllQuery);
        }

        public virtual async Task<bool> InsertAsync(TEntity entity)
        {
            var result = await _context.ExecuteAsync(InsertQuery, entity);
            return result > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            var result = await _context.ExecuteAsync(UpdateQuery, entity);
            return result > 0;
        }

        public virtual async Task<bool> DeleteAsync(TKey id)
        {
            var result = await _context.ExecuteAsync(DeleteQuery, new { Id = id });
            return result > 0;
        }
    }
}
