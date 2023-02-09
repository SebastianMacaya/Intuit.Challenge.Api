using Microsoft.EntityFrameworkCore;

namespace Api.Intuit.Infrastructure.Data.Contracts
{
    public interface IUnitOfWork<TDbContext, TEntity> : IDisposable
        where TDbContext : DbContext
        where TEntity : EntityBase
    {
        IRepositoryCommand<TDbContext, TEntity> RepositoryCommand { get; }
        IRepositoryQuery<TDbContext, TEntity> RepositoryQuery { get; }

        Task SaveChangesAsync();

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
