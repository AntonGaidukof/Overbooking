using System;
using System.Linq;
using System.Threading.Tasks;
using TLOverbookingApi.Dto.RoomStayFact;
using TLOverbookingApplication.RoomStayFactExtraction.Services;
using TLOverbookingDomain.Abstractions;
using TLOverbookingDomain.RoomStayFact;

namespace TLOverbookingApi.Services.RoomStay
{
    public class RoomStayFactApiService : IRoomStayFactApiService
    {
        private readonly IRoomStayFactExtractionService _roomStayFactExtractionService;
        private readonly IRoomStayFactService _roomStayFactService;
        private readonly IUnitOfWork _unitOfWork;

        public RoomStayFactApiService( 
            IRoomStayFactExtractionService roomStayFactExtractionService,
            IRoomStayFactService roomStayFactService,
            IUnitOfWork unitOfWork )
        {
            _roomStayFactExtractionService = roomStayFactExtractionService;
            _roomStayFactService = roomStayFactService;
            _unitOfWork = unitOfWork;
        }

        public async Task ExtractAsync( long providerId )
        {
            await _roomStayFactExtractionService.ExtractRoomStayFactsAsync( providerId );
            await _unitOfWork.CommitAsync();
        }

        public void Add( RoomStayFactsDto roomStayFactsDto )
        {
            if ( roomStayFactsDto?.RoomStayFacts == null )
            {
                throw new ArgumentException( "Incorrect input data" );
            }

            var roomStayFacts = roomStayFactsDto.RoomStayFacts.Select( ConvertToRoomStayFact );

            _roomStayFactService.AddRange( roomStayFacts );
            _unitOfWork.Commit();
        }

        public async Task<RoomStayFactsDto> GetAllForProviderAsync( long providerId )
        {
            var roomStayFacts = await _roomStayFactService.GetAllForProviderAsync( providerId );
            return new RoomStayFactsDto
            {
                RoomStayFacts = roomStayFacts.Select( ConvertToRoomStayFactDto ).ToList()
            };
        }

        private RoomStayFact ConvertToRoomStayFact( RoomStayFactDto roomStayFactDto )
        {
            return new RoomStayFact
            {
                AdultsAmount = roomStayFactDto.AdultsAmount,
                CheckInDate = DateTime.Parse( roomStayFactDto.CheckInDate ),
                CheckOutDate = DateTime.Parse( roomStayFactDto.CheckOutDate ),
                ChildrenAmount = roomStayFactDto.ChildrenAmount,
                DaysBetweenCheckInAndCanceling = roomStayFactDto.DaysBetweenCheckInAndCanceling,
                DuratuionInDays = roomStayFactDto.DuratuionInDays,
                ExternalId = Convert.ToInt64( roomStayFactDto.ExternalId ),
                Id = !String.IsNullOrEmpty( roomStayFactDto.Id ) ? Convert.ToInt64( roomStayFactDto.Id ) : default,
                IsCancelled = roomStayFactDto.IsCancelled,
                ProviderId = Convert.ToInt64( roomStayFactDto.ProviderId ),
                RatePlanId = Convert.ToInt64( roomStayFactDto.RatePlanId ),
                RoomId = Convert.ToInt64( roomStayFactDto.RoomId ),
                RoomTypeId = Convert.ToInt64( roomStayFactDto.RoomTypeId ),
                Total = Convert.ToInt64( roomStayFactDto.Total )
            };
        }

        private RoomStayFactDto ConvertToRoomStayFactDto( RoomStayFact roomStayFact )
        {
            return new RoomStayFactDto
            {
                AdultsAmount = roomStayFact.AdultsAmount,
                CheckInDate = roomStayFact.CheckInDate.ToString(),
                CheckOutDate = roomStayFact.CheckOutDate.ToString(),
                ChildrenAmount = roomStayFact.ChildrenAmount,
                DaysBetweenCheckInAndCanceling = roomStayFact.DaysBetweenCheckInAndCanceling,
                DuratuionInDays = roomStayFact.DuratuionInDays,
                ExternalId = roomStayFact.ExternalId.ToString(),
                Id = roomStayFact.Id.ToString(),
                IsCancelled = roomStayFact.IsCancelled,
                ProviderId = roomStayFact.ProviderId.ToString(),
                RatePlanId = roomStayFact.RatePlanId.ToString(),
                RoomId = roomStayFact.RoomId.ToString(),
                RoomTypeId = roomStayFact.RoomTypeId.ToString(),
                Total = roomStayFact.Total.ToString()
            };
        }
    }
}
