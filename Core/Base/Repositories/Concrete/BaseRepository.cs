using Core.Base.Entities;
using Core.Base.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Base.Repositories.Concrete
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> data = _dbContext.Set<TEntity>();
            if (include != null)
                data = include(data);

            return await data.FirstOrDefaultAsync(predicate);

        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> data = _dbContext.Set<TEntity>();
            if (predicate != null)
                data = data.Where(predicate);
            if (include != null)
                data = include(data);
            return await data.ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
