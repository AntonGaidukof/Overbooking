using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLOverbookingDomain.Provider;
using TLOverbookingInfrastructure.Foundation;

namespace TLOverbookingInfrastructure.Repositopries
{
    public class ProviderPredictionModelRepository : BaseRepository<ProviderPredictionModel>, IProviderPredictionModelRepository
    {
        public ProviderPredictionModelRepository( TLOverbookingDbContext dbContext )
             : base( dbContext )
        {
        }

        public Task AddRangeAsync( List<ProviderPredictionModel> entities )
        {
            throw new System.NotImplementedException();
        }

        public ProviderPredictionModel GetById( long providerId )
        {
            throw new System.NotImplementedException();
        }
    }
}
