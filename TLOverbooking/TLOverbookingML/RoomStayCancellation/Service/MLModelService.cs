using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLOverbookingDomain.RoomStayCancellation;
using TLOverbookingML.RoomStayCancellation.Consumer;
using TLOverbookingML.RoomStayCancellation.Model;

namespace TLOverbookingML.RoomStayCancellation.Service
{
    public class MLModelService : IMLModelService
    {
        private IRoomStayDataViewService _roomStayDataViewService;
        private IRoomStayCancellationModelService _roomStayCancellationModelService;

        public MLModelService( IRoomStayDataViewService roomStayDataViewService, IRoomStayCancellationModelService roomStayCancellationModelService )
        {
            _roomStayDataViewService = roomStayDataViewService;
            _roomStayCancellationModelService = roomStayCancellationModelService;
        }

        public async Task<string> CreeateModelAsync( long providerId )
        {
            var mlContext = new MLContext( seed: 1 );
            var trainingDataView = await _roomStayDataViewService.GetDataViewAsync( providerId, mlContext );

            IEstimator<ITransformer> trainingPipeline = BuildTrainingPipeline( mlContext );

            ITransformer mlModel = TrainModel( mlContext, trainingDataView, trainingPipeline );

            Evaluate( mlContext, trainingDataView, trainingPipeline );

            var roomStayCancellationModel = _roomStayCancellationModelService.Rebuild( providerId );

            SaveModel( mlContext, mlModel, roomStayCancellationModel.Path, trainingDataView.Schema );

            return string.Empty;
        }

        public Dictionary<long, ModelOutput> Predict( Dictionary<long, ModelInput> modelInputs, string modelPath )
        {
            var result = new Dictionary<long, ModelOutput>();
            var consumeModel = new ConsumeModel();

            foreach ( var modelInputItem in modelInputs )
            {
                var rand = new Random();
                var modelOutput = new ModelOutput
                {
                    Prediction = consumeModel.Predict( modelInputItem.Value ).Prediction
                };

                result.Add( modelInputItem.Key, modelOutput );
            }

            return result;
        }

        private IEstimator<ITransformer> BuildTrainingPipeline( MLContext mlContext )
        {
            var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey( "IsCancelled", "IsCancelled" )
                                      .Append( mlContext.Transforms.Categorical.OneHotEncoding( new[]
                                      {
                                            new InputOutputColumnPair( "DuratuionInDays", "DuratuionInDays" ),
                                            new InputOutputColumnPair( "CheckInDate", "CheckInDate" ),
                                            new InputOutputColumnPair( "CheckOutDate", "CheckOutDate" ),
                                            new InputOutputColumnPair( "Total", "Total" ),
                                            new InputOutputColumnPair( "AdultsAmount", "AdultsAmount" ),
                                            new InputOutputColumnPair( "ChildrenAmount", "ChildrenAmount" ),
                                            new InputOutputColumnPair( "RoomTypeId", "RoomTypeId" ),
                                            new InputOutputColumnPair( "RoomId", "RoomId" ),
                                            new InputOutputColumnPair( "RatePlanId", "RatePlanId" ),
                                            new InputOutputColumnPair( "CreationSource", "CreationSource" ),
                                            new InputOutputColumnPair( "PurposeKind", "PurposeKind" ),
                                            new InputOutputColumnPair( "DaysBetweenCheckInAndCanceling", "DaysBetweenCheckInAndCanceling" )
                                      } ) )
                                      .Append( mlContext.Transforms.Concatenate( "Features", new[]
                                      {
                                          "DuratuionInDays",
                                          "CheckInDate",
                                          "CheckOutDate",
                                          "Total",
                                          "AdultsAmount",
                                          "ChildrenAmount",
                                          "RoomTypeId",
                                          "RoomId",
                                          "RatePlanId",
                                          "CreationSource",
                                          "PurposeKind",
                                          "DaysBetweenCheckInAndCanceling",
                                      } ) )
                                      .Append( mlContext.Transforms.NormalizeMinMax( "Features", "Features" ) )
                                      .AppendCacheCheckpoint( mlContext );
            var trainer = mlContext.MulticlassClassification.Trainers.OneVersusAll( mlContext.BinaryClassification.Trainers.AveragedPerceptron( labelColumnName: "IsCancelled", numberOfIterations: 10, featureColumnName: "Features" ), labelColumnName: "IsCancelled" )
                                      .Append( mlContext.Transforms.Conversion.MapKeyToValue( "PredictedLabel", "PredictedLabel" ) );

            var trainingPipeline = dataProcessPipeline.Append( trainer );

            return trainingPipeline;
        }

        private ITransformer TrainModel( MLContext mlContext, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline )
        {
            Console.WriteLine( "=============== Training  model ===============" );

            ITransformer model = trainingPipeline.Fit( trainingDataView );

            Console.WriteLine( "=============== End of training process ===============" );
            return model;
        }

        private void Evaluate( MLContext mlContext, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline )
        {
            Console.WriteLine( "=============== Cross-validating to get model's accuracy metrics ===============" );
            mlContext.MulticlassClassification.CrossValidate( trainingDataView, trainingPipeline, numberOfFolds: 5, labelColumnName: "IsCancelled" );
        }

        private void SaveModel( MLContext mlContext, ITransformer mlModel, string modelRelativePath, DataViewSchema modelInputSchema )
        {
            Console.WriteLine( $"=============== Saving the model  ===============" );
            mlContext.Model.Save( mlModel, modelInputSchema, modelRelativePath );
        }
    }
}
