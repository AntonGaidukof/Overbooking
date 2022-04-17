using System.Threading.Tasks;

namespace TLOverbookingApplication.RoomStayCancellation.Services
{
    public interface ILearningModelService
    {
        public Task StartLearningAsync( long providerId, bool startFactExtraction = true );
    }
}
