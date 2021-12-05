namespace TLOverbookingDomain.Provider
{
    public interface IProviderPredictionModelRepository
    {
        ProviderPredictionModel GetById( long providerId );
    }
}
