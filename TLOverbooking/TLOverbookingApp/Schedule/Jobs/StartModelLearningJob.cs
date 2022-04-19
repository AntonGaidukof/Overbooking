using Quartz;
using System;
using System.Threading.Tasks;

namespace TLOverbookingApp.Schedule.Jobs
{
    public class StartModelLearningJob : IJob
    {
        public Task Execute( IJobExecutionContext context )
        {
            Console.WriteLine( "StartModelLearningJob executed!" );
            return Task.CompletedTask;
        }
    }
}
