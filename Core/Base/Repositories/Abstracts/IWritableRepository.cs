using Core.Base.Entities;

namespace Core.Base.Repositories.Abstracts
{
    public interface IWritableRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);   
        Task UpdateAsync(TEntity entity);
    }
}
