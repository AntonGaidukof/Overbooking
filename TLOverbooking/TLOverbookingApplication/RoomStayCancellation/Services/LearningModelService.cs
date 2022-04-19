using System;
using System.Threading.Tasks;
using TLOverbookingApplication.RoomStayFactExtraction.Services;
using TLOverbookingDomain.RoomStayCancellation;

namespace TLOverbookingApplication.RoomStayCancellation.Services
{
    public class LearningModelService : ILearningModelService
    {
        private readonly IRoomStayCancellationLearningProcessService _processService;
        private readonly IRoomStayFactExtractionService _factExtractionService;

        public LearningModelService( 
            IRoomStayCancellationLearningProcessService processService,
            IRoomStayFactExtractionService factExtractionService )
        {
            _processService = processService;
            _factExtractionService = factExtractionService;
        }

        public async Task StartLearningAsync( long providerId, bool startFactExtraction = true )
        {
            var currentActiveProcess = _processService.GetCurrentActiveProcess( providerId );

            if ( currentActiveProcess != null )
            {
                return;
            }

            if ( startFactExtraction )
            {
                await _factExtractionService.ExtractRoomStayFactsAsync( providerId );
            }

            var learningProcess = new RoomStayCancellationLearningProcess
            {
                ProviderId = providerId,
                Status = LearningStatus.Started,
                TimeStampUtc = DateTime.UtcNow
            };

            _processService.Add( learningProcess );
        }
    }
}
