using Microsoft.EntityFrameworkCore;

namespace Api.Intuit.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> WithTracking<TEntity>(this IQueryable<TEntity> source, bool traking)
            where TEntity : class
        {
            if (traking)
            {
                source.AsTracking();
            }
            else
            {
                source.AsNoTracking();
            }

            return source;
        }
    }
}
