using System;
using System.Linq;
using System.Threading.Tasks;
using TLOverbookingApi.Dto.CancellationPrediction.RoomStay;
using TLOverbookingApplication.RoomStayCancellation.Entities;
using TLOverbookingApplication.RoomStayCancellation.Services;
using TLOverbookingDomain.Abstractions;
using TLOverbookingML.RoomStayCancellation.Service;

namespace TLOverbookingApi.Services.RoomStay
{
    public class CancellationPredictionApiService : ICancellationPredictionApiService
    {
        private readonly ILearningModelService _learningModelService;
        private readonly IPredictionService _predictionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMLModelService _mLModelService;

        public CancellationPredictionApiService( 
            ILearningModelService learningModelService,
            IPredictionService predictionService,
            IUnitOfWork unitOfWork,
            IMLModelService mLModelService )
        {
            _learningModelService = learningModelService;
            _predictionService = predictionService;
            _unitOfWork = unitOfWork;
            _mLModelService = mLModelService;
        }

        public Task CreateDataView( long providerId )
        {
            return _mLModelService.CreeateModelAsync( providerId );
        }

        public CancellationPredictionsDto GetCancellationPredictions( GetCancellationPredictionDto request )
        {
            var cancellationPredictionRQ = new GetCancellationPrediction
            {
                ProviderId = request.ProviderId,
                RoomStays = request.RoomStays.Select( ConvertRoomStayForPredictionFromDto ).ToList()
            };

            var result = _predictionService.GetCancellationPrediction( cancellationPredictionRQ );

            return new CancellationPredictionsDto
            {
                CancellationPredictions = result.CancellationPredictions.Select( p => new CancellationPredictionDto
                {
                    ExternalId = p.RoomStayId,
                    IsCancelled = p.IsCancelled
                } ).ToList()
            };
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

        private RoomStayForPrediction ConvertRoomStayForPredictionFromDto( RoomStayForPredictionDto roomStay )
        {
            return new RoomStayForPrediction
            {
                Total = roomStay.Total,
                CheckInDate = DateTime.Parse( roomStay.CheckInDate ),
                CheckOutDate = DateTime.Parse( roomStay.CheckOutDate ),
                AdultsAmount = roomStay.AdultsAmount,
                ChildrenAmount = roomStay.ChildrenAmount,
                CreationSource = roomStay.CreationSource,
                ExternalId = roomStay.ExternalId,
                PurposeKind = roomStay.PurposeKind,
                RatePlanId = roomStay.RatePlanId,
                RoomId = roomStay.RoomId,
                RoomTypeId = roomStay.RoomTypeId
            };
        }
    }
}
