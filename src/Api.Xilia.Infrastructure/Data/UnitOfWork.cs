using Api.Intuit.Infrastructure.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Api.Intuit.Infrastructure.Data
{
    public class UnitOfWork<TDbContext, TEntity> : IUnitOfWork<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : EntityBase
    {
        private bool disposed = false;
        private readonly bool traking = false;
        private readonly DbContext dbContext;
        private IRepositoryCommand<TDbContext, TEntity>? repositoryCommand;
        private IRepositoryQuery<TDbContext, TEntity>? repositoryQuery;

        public UnitOfWork(IDbContextFactory<TDbContext> dbFactory, bool traking)
        {
            dbContext = dbFactory.CreateDbContext();
            this.traking = traking;
        }

        public IRepositoryCommand<TDbContext, TEntity> RepositoryCommand
        {
            get => repositoryCommand = repositoryCommand ?? new RepositoryCommand<TDbContext, TEntity>((TDbContext)dbContext, traking);
        }

        public IRepositoryQuery<TDbContext, TEntity> RepositoryQuery
        {
            get => repositoryQuery = repositoryQuery ?? new RepositoryQuery<TDbContext, TEntity>((TDbContext)dbContext, traking);
        }

        public async Task SaveChangesAsync()
        {
            await SaveChangesAsync(CancellationToken.None);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            using (IDbContextTransaction dbContextTransaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await dbContext.SaveChangesAsync(cancellationToken);
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }

            disposed = true;
        }
    }
}
