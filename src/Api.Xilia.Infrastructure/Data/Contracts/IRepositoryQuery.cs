using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Intuit.Infrastructure.Data.Contracts
{
    public interface IRepositoryQuery<TDbContext, TEntity>
        where TEntity : EntityBase
        where TDbContext : DbContext
    {
        IQueryable<TEntity> Queryable();
            
        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        IList<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);

        TEntity? GetById(params object[] keyValues);

        Task<TEntity?> GetByIdAsync(params object[] keyValues);

        Task<TEntity?> GetByIdAsync(CancellationToken cancellationToken, params object[] keyValues);

        TEntity? GetFirstOrDefault(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetByQueryString(string sqlQuery);
    }
}
