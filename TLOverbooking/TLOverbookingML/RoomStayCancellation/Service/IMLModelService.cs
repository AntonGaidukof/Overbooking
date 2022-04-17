using System.Collections.Generic;
using TLOverbookingML.RoomStayCancellation.Model;

namespace TLOverbookingML.RoomStayCancellation.Service
{
    public interface IMLModelService
    {
        public string CreeateModel( long providerId );

        public void DeleteModel( string modelPath );

        public Dictionary<long, ModelOutput> Predict( Dictionary<long, ModelInput> modelInputs, string modelPath );
    }
}
