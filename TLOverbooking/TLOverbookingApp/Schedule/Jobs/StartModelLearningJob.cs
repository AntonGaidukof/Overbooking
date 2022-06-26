using Quartz;
using System;
using System.Threading.Tasks;
using TLOverbookingDomain.RoomStayFact;
using TLOverbookingML.RoomStayCancellation.Service;

namespace TLOverbookingApp.Schedule.Jobs
{
    public class StartModelLearningJob : IJob
    {
        private readonly IRoomStayFactService _roomStayFactService;
        private readonly IRoomStayDataViewService _roomStayDataViewService;


        public Task Execute( IJobExecutionContext context )
        {
            /*
             * 1) Вызываем IMLModelService.CreeateModel
             * 2) Полученную строку сохраняем в бд в RoomStayCancellationModel
             * 3) Создание таска на получение фактов через неделю
            */

            Console.WriteLine( "StartModelLearningJob executed!" );
            return Task.CompletedTask;
        }
    }
}
