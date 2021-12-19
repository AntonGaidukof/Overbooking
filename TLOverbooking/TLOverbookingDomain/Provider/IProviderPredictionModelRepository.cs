using TLOverbookingDomain.Abstractions;

namespace TLOverbookingDomain.Provider
{
    public interface IProviderPredictionModelRepository : IBaseRepository<ProviderPredictionModel>
    {
        ProviderPredictionModel GetById( long providerId );
    }
}
