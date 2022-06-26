using System.Collections.Generic;
using System.Threading.Tasks;
using TLOverbookingML.RoomStayCancellation.Model;

namespace TLOverbookingML.RoomStayCancellation.Service
{
    public interface IMLModelService
    {
        public Task<string> CreeateModelAsync( long providerId );

        public Dictionary<long, ModelOutput> Predict( Dictionary<long, ModelInput> modelInputs, string modelPath );
    }
}
