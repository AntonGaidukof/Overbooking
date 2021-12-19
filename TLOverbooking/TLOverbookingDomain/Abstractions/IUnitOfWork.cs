using System.Threading.Tasks;

namespace TLOverbookingDomain.Abstractions
{
    public interface IUnitOfWork
    {
        void Commit();

        Task CommitAsync();
    }
}
