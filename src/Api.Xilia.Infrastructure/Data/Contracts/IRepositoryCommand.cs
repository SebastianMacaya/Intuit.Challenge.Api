using Microsoft.EntityFrameworkCore;

namespace Api.Intuit.Infrastructure.Data.Contracts
{
    public interface IRepositoryCommand<TDbContext, TEntity>
        where TEntity : EntityBase
        where TDbContext : DbContext
    {
        TEntity Create(TEntity entity);

        IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities);

        void Delete(params object[] keyValues);

        void Delete(TEntity entityToDelete);

        TEntity Update(TEntity entityToUpdate);

        Task<TEntity> UpdateAsync(TEntity entityToUpdate);
    }
}
