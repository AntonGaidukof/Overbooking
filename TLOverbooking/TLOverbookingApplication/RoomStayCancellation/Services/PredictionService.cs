using System;
using System.Collections.Generic;
using System.Linq;
using TLOverbookingApplication.RoomStayCancellation.Entities;
using TLOverbookingApplication.RoomStayCancellation.Exceptions;
using TLOverbookingApplication.RoomStayFactExtraction.Entities;
using TLOverbookingDomain.RoomStayCancellation;
using TLOverbookingDomain.RoomStayFact;
using TLOverbookingML.RoomStayCancellation.Model;
using TLOverbookingML.RoomStayCancellation.Service;

namespace TLOverbookingApplication.RoomStayCancellation.Services
{
    public class PredictionService : IPredictionService
    {
        private readonly IMLModelService _mLModelService;
        private readonly IRoomStayFactService _roomStayFactService;
        private readonly IRoomStayCancellationModelService _roomStayCancellationModelService;

        public PredictionService( 
            IMLModelService mLModelService,
            IRoomStayFactService roomStayFactService,
            IRoomStayCancellationModelService roomStayCancellationModelService )
        {
            _mLModelService = mLModelService;
            _roomStayFactService = roomStayFactService;
            _roomStayCancellationModelService = roomStayCancellationModelService;
        }

        public GetCancellationPredictionResult GetCancellationPrediction( GetCancellationPrediction request )
        {
            /*
             * 1) Получаем все RoomFact из бд
             * 2) Конвертируем в InputModel
             * 3) Запускаем прогнозирование
             * 4) Конвертируем полученный результат
             * 5) Возвращаем результат
             */
            if ( request == null || request.RoomStays.Count == 0 )
            {
                return new GetCancellationPredictionResult
                {
                    CancellationPredictions = new List<Entities.CancellationPrediction>()
                };
            }


            var mlModels = request.RoomStays.ToDictionary( rs => rs.ExternalId, rs =>  ConvertToMLModel( rs, request.ProviderId ) );
            var predictionModel = _roomStayCancellationModelService.Get( request.ProviderId );

            if ( predictionModel == null )
            {
                throw new PredictionModelNotFoundexception( $"Prediction model not found for provider {request.ProviderId}" );
            }

            var predictionResult = _mLModelService.Predict( mlModels, predictionModel.Path );
            return new GetCancellationPredictionResult
            {
                CancellationPredictions = predictionResult.Select( pr => new CancellationPrediction
                {
                    RoomStayId = pr.Key,
                    IsCancelled = pr.Value.Prediction
                } ).ToList(),
            };
        }

        private ModelInput ConvertToMLModel( RoomStayForPrediction rs, long providerId )
        {
            return new ModelInput
            {
                AdultsAmount = rs.AdultsAmount,
                CheckInDate = rs.CheckInDate,
                CheckOutDate = rs.CheckOutDate,
                ChildrenAmount = rs.ChildrenAmount,
                DaysBetweenCheckInAndCanceling = 0,
                DuratuionInDays = 0,
                RatePlanId = rs.RatePlanId,
                RoomId = rs.RoomId,
                RoomTypeId = rs.RoomTypeId,
                CreationSource = rs.CreationSource,
                PurposeKind = rs.PurposeKind,
                Total = rs.Total
            };
        }
    }
}
