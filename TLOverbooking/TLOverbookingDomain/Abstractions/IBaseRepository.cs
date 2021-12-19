using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TLOverbookingDomain.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        void Add( T entity );

        void Remove( T entity );

        void RemoveRange( IEnumerable<T> entities );

        void AddRange( IEnumerable<T> entities );

        IQueryable<T> GetQuery();
    }
}
