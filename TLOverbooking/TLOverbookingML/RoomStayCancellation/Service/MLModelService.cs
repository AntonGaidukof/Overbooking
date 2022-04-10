using TLOverbookingML.RoomStayCancellation.Model;

namespace TLOverbookingML.RoomStayCancellation.Service
{
    public class MLModelService : IMLModelService
    {
        public string CreeateModel( long providerId )
        {
            throw new System.NotImplementedException();

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
            throw new System.NotImplementedException();
        }

        public ModelOutput Predict( ModelInput input, long providerId, string modelPath )
        {
            // Можно спокойно копипастить код из ConsumeModel
        }
    }
}
