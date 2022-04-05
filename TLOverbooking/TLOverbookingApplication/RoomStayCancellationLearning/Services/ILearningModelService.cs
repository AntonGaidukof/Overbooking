using System.Threading.Tasks;

namespace TLOverbookingApplication.RoomStayCancellationLearning.Services
{
    public interface ILearningModelService
    {
        public Task StartLearningAsync( long providerId, bool startFactExtraction = true );
    }
}
