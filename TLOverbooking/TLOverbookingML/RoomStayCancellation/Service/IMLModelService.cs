using TLOverbookingML.RoomStayCancellation.Model;

namespace TLOverbookingML.RoomStayCancellation.Service
{
    public interface IMLModelService
    {
        public string CreeateModel( long providerId );

        public void DeleteModel( string modelPath );

        public ModelOutput Predict( ModelInput input, long providerId, string modelPath );
    }
}
