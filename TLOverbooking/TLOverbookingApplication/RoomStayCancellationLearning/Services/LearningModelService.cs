using System;
using System.Threading.Tasks;
using TLOverbookingApplication.RoomStayFactExtraction.Services;
using TLOverbookingDomain.RoomStayCancellation;

namespace TLOverbookingApplication.RoomStayCancellationLearning.Services
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
            var currentLearningProcess = await _processService.GetAsync( providerId, LearningStatus.Processing );

            if ( currentLearningProcess != null )
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
                Status = LearningStatus.Processing,
                TimeStampUtc = DateTime.UtcNow
            };

            _processService.Add( learningProcess );
        }
    }
}
