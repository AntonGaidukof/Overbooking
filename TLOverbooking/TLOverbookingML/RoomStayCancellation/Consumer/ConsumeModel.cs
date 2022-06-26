using Microsoft.ML;
using System;
using TLOverbookingML.RoomStayCancellation.Model;

namespace TLOverbookingML.RoomStayCancellation.Consumer
{
    public class ConsumeModel
    {
        // TODO получать путь модели через конфиг файл
        private static string _modelPath = @"C:\Users\anton\AppData\Local\Temp\MLVSTools\ClassificationModelML\ClassificationModelML.Model\MLModel.zip";
        private static Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictionEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>( CreatePredictionEngine );

        public ModelOutput Predict( ModelInput input )
        {
            ModelOutput result = PredictionEngine.Value.Predict( input );
            return result;
        }

        public static PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            ITransformer mlModel = mlContext.Model.Load( _modelPath, out var modelInputSchema );
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>( mlModel );

            return predEngine;
        }
    } 
}
