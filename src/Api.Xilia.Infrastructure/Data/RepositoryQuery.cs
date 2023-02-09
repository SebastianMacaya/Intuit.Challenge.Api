using Api.Intuit.Infrastructure.Data.Contracts;
using Api.Intuit.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Intuit.Infrastructure.Data
{
    public class RepositoryQuery<TDbContext, TEntity> : IRepositoryQuery<TDbContext, TEntity>
        where TEntity : EntityBase
        where TDbContext : DbContext
    {
        private readonly bool traking = false;
        private readonly DbContext context;
        private readonly DbSet<TEntity> dbentitySet;

        public RepositoryQuery(TDbContext context, bool traking)
        {
            this.context = context;
            ValidateEntityInDbContext();

            this.traking = traking;
            dbentitySet = context.Set<TEntity>();
        }

        public virtual IList<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return GetQuery(filter, orderBy, includes).ToList();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbentitySet.WithTracking(traking).AsEnumerable().ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbentitySet.WithTracking(traking).ToListAsync();
        }

        public virtual async Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return await GetQuery(filter, orderBy, includes).ToListAsync();
        }

        public virtual TEntity? GetById(params object[] keyValues)
        {

            TEntity? entity = dbentitySet.Find(keyValues);

            if (!traking)
            {
                context.Entry(entity).State = EntityState.Detached;
            }

            return entity;

        }

        public virtual async Task<TEntity?> GetByIdAsync(params object[] keyValues)
        {

            TEntity? entity = await dbentitySet.FindAsync(keyValues);

            if (!traking)
            {
                context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public virtual async Task<TEntity?> GetByIdAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            TEntity? entity = await dbentitySet.FindAsync(cancellationToken, keyValues);

            if (!traking)
            {
                context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetByQueryString(string sqlQuery)
        {
            List<TEntity> result = await context.Set<TEntity>().FromSqlRaw(sqlQuery).ToListAsync();
            context.Dispose();

            return result;
        }

        public virtual TEntity? GetFirstOrDefault(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbentitySet;

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            return query.WithTracking(traking).FirstOrDefault(filter);
        }

        public virtual async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            return await query.WithTracking(traking).FirstOrDefaultAsync(filter);
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            IQueryable<TEntity> query = dbentitySet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.WithTracking(traking);
        }

        public virtual IQueryable<TEntity> Queryable()
        {
            return dbentitySet.WithTracking(traking);
        }

        private void ValidateEntityInDbContext()
        {
            if (context.Model.FindEntityType(typeof(TEntity)) == null)
            {
                throw new Exception($"The entity type {typeof(TEntity)} is not in the DbContext {typeof(TDbContext).Name}");
            }
        }

        private IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbentitySet;

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.WithTracking(traking);
        }
    }
}
