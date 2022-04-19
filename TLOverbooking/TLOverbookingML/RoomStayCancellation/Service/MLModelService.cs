using System;
using System.Collections.Generic;
using TLOverbookingML.RoomStayCancellation.Model;

namespace TLOverbookingML.RoomStayCancellation.Service
{
    public class MLModelService : IMLModelService
    {
        public string CreeateModel( long providerId )
        {
            return string.Empty;

            /*
             * 1) Формируем строку с путем, где будет хранится модель
             * 2) Формируем файл с тренировачными данными
             * 3) Запускаем процесс создания модели и обучения через IMLModelBuilder
             * 4) Сохраняем полученный результат
             * 5) Возвращаем строку с расположением модели
             */
        }

        public void DeleteModel( string modelPath )
        {
        }

        public Dictionary<long, ModelOutput> Predict( Dictionary<long, ModelInput> modelInputs, string modelPath )
        {
            // Можно спокойно копипастить код из ConsumeModel, когда дойдет дело до нормальной реализации

            var result = new Dictionary<long, ModelOutput>();

            foreach ( var modelInputItem in modelInputs )
            {
                var rand = new Random();
                var modelOutput = new ModelOutput
                {
                    Prediction = rand.NextDouble() >= 0.5
                };

                result.Add( modelInputItem.Key, modelOutput );
            }

            return result;
        }
    }
}
