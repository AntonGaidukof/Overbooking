using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TLOverbookingDomain.Abstractions;

namespace TLOverbookingInfrastructure.Repositopries
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbContext DbContext;

        protected DbSet<T> Entities => DbContext.Set<T>();

        public BaseRepository( DbContext dbContext )
        {
            DbContext = dbContext;
        }

        public void Remove( T entity )
        {
            DbContext.Remove( entity );
        }

        public void AddRange( IEnumerable<T> entities )
        {
            DbContext.AddRange( entities );
        }

        public IQueryable<T> GetQuery()
        {
            return Entities.AsQueryable();
        }

        public void Add( T entity )
        {
            DbContext.Add( entity );
        }

        public void RemoveRange( IEnumerable<T> entities )
        {
            DbContext.RemoveRange( entities );
        }
    }
}
