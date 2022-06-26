using Quartz;
using System.Threading.Tasks;

namespace TLOverbookingApp.Schedule.Jobs
{
    public class StartRoomStayExtractionJob : IJob
    {
        public Task Execute( IJobExecutionContext context )
        {
            /*
             * 1) Запуск IRoomStayFactExtractionService.ExtractRoomStayFactsAsync
             * 2) Создание таска на обновление модели RoomStayCancellationLearningProcess
             */

            throw new System.NotImplementedException();
        }
    }
}
