using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TLOverbookingDomain.Abstractions;

namespace TLOverbookingInfrastructure.Foundation
{
    public class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        protected readonly T DbContext;

        public UnitOfWork( T dbContext )
        {
            DbContext = dbContext;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
