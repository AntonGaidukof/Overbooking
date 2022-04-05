using System;
using System.Threading.Tasks;
using TLOverbookingApi.Dto.RoomStayCancellationPrediction;
using TLOverbookingApplication.RoomStayCancellationLearning.Services;
using TLOverbookingDomain.Abstractions;

namespace TLOverbookingApi.Services
{
    public class RoomStayCancellationPredictionApiService : IRoomStayCancellationPredictionApiService
    {
        private ILearningModelService _learningModelService;
        private IUnitOfWork _unitOfWork;

        public RoomStayCancellationPredictionApiService( 
            ILearningModelService learningModelService,
            IUnitOfWork unitOfWork )
        {
            _learningModelService = learningModelService;
            _unitOfWork = unitOfWork;
        }

        public async Task StartLearningAsync( ModelStartLearningDto modelStartLearningDto )
        {
            if ( modelStartLearningDto == null )
            {
                throw new ArgumentException( $"ModelStartLearningDto is null" );
            }

            await _learningModelService.StartLearningAsync( modelStartLearningDto.ProviderId, modelStartLearningDto.StartExtraction );
            await _unitOfWork.CommitAsync();
        }
    }
}
