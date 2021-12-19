using System;

namespace TLOverbookingDomain.Provider
{
    public class ProviderPredictionModel
    {
        public long Id { get; set; }

        public long ProviderId { get; set; }

        public string Key { get; set; }

        public DateTime LastModified { get; set; }
    }
}
