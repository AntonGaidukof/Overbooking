using System;
using System.Linq;
using System.Threading.Tasks;
using TLOverbookingApi.Dto;
using TLOverbookingApplication.RoomStayFactExtraction.Services;
using TLOverbookingDomain.RoomStayFact;

namespace TLOverbookingApi.Services
{
    public class RoomStayFactApiService : IRoomStayFactApiService
    {
        private readonly IRoomStayFactExtractionService _roomStayFactExtractionService;
        private readonly IRoomStayFactService _roomStayFactService;

        public RoomStayFactApiService( IRoomStayFactExtractionService roomStayFactExtractionService, IRoomStayFactService roomStayFactService )
        {
            _roomStayFactExtractionService = roomStayFactExtractionService;
            _roomStayFactService = roomStayFactService;
        }

        public async Task ExtractAsync( long? providerId )
        {
            if ( !providerId.HasValue )
            {
                // TODO переделать на нормальный Exception
                throw new ArgumentException();
            }

            await _roomStayFactExtractionService.ExtractRoomStayFactsAsync( providerId.Value );
        }

        public void Add( RoomStayFactDto roomStayFactDto )
        {
            if ( roomStayFactDto == null )
            {
                throw new ArgumentException();
            }

            RoomStayFact roomStayFact = ConvertToRoomStayFact( roomStayFactDto );

            _roomStayFactService.AddRange( new[] { roomStayFact } );
        }

        public async Task<RoomStayFactDto[]> GetAllAsync()
        {
            return ( await _roomStayFactService.GetAllAsync() ).Select( ConvertToRoomStayFactDto ).ToArray();
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
                Id = Convert.ToInt64( roomStayFactDto.Id ),
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
