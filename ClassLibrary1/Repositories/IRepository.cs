
using System.Linq.Expressions;

namespace BLL
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IReadOnlyList<TEntity>> ListAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> UpdateAsync_Return(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IReadOnlyList<TEntity>> GetAllAsync(ISpecification<TEntity> spec);
        Task<TEntity> GetByIdAsync( ISpecification<TEntity> spec);
        Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spec);
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> value = null);
    }
}
