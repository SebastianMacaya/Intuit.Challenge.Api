using Api.Intuit.Infrastructure.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api.Intuit.Infrastructure.Data
{
    public class RepositoryCommand<TDbContext, TEntity> : IRepositoryCommand<TDbContext, TEntity>
        where TEntity : EntityBase
        where TDbContext : DbContext
    {
        private readonly bool traking = false;
        private readonly DbContext context;
        private readonly DbSet<TEntity> dbentitySet;

        public RepositoryCommand(TDbContext context, bool traking)
        {
            this.context = context;
            ValidateEntityInDbContext();

            this.traking = traking;
            dbentitySet = context.Set<TEntity>();
        }

        public TEntity Create(TEntity entity)
        {
            EntityEntry<TEntity> newEntity = dbentitySet.Add(entity);

            return newEntity.Entity;
        }

        public IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entities)
        {
            dbentitySet.AddRange(entities);

            return entities;
        }

        public void Delete(params object[] keyValues)
        {
            TEntity? entityToDelete = dbentitySet.Find(keyValues);

            if (entityToDelete == null)
            {
                var name = typeof(TEntity).Name;

                throw new ApplicationException($"La entidad '{name}' con ID {string.Join(",", keyValues)} no existe.");
            }

            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbentitySet.Attach(entityToDelete);
            }

            EntityEntry<TEntity> deletedEntity = dbentitySet.Remove(entityToDelete);

        }

        public TEntity Update(TEntity entityToUpdate)
        {

            EntityEntry<TEntity> entityUpdated = dbentitySet.Attach(entityToUpdate);

            context.Entry(entityToUpdate).State = EntityState.Modified;

            return entityUpdated.Entity;

        }

        public async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {

            EntityEntry<TEntity> entityUpdated = dbentitySet.Attach(entityToUpdate);

            context.Entry(entityToUpdate).State = EntityState.Modified;

            await Task.CompletedTask;

            return entityUpdated.Entity;

        }

        private void ValidateEntityInDbContext()
        {
            if (context.Model.FindEntityType(typeof(TEntity)) == null)
            {
                throw new Exception($"The entity type {typeof(TEntity)} is not in the DbContext {typeof(TDbContext).Name}");
            }
        }
    }
}
