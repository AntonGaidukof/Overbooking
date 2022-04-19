using Quartz;
using Quartz.Impl;
using TLOverbookingApp.Schedule.Jobs;

namespace TLOverbookingApp.Schedule
{
    public class TaskInitializer
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail startModelLearningJob = JobBuilder.Create<StartModelLearningJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()  // создаем триггер
                .WithIdentity( "StartModelLearningJobTrigger", "ModelLearningGroup" )     // идентифицируем триггер с именем и группой
                .StartNow()                            // запуск сразу после начала выполнения
                .WithSimpleSchedule( x => x            // настраиваем выполнение действия
                     .WithIntervalInSeconds( 3 )          // через 1 минуту
                     .RepeatForever() )                   // бесконечное повторение
                .Build();

            await scheduler.ScheduleJob( startModelLearningJob, trigger );
        }
    }
}
