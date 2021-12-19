using System;
using System.Threading.Tasks;
using TLOverbookingApplication.RoomStayFactExtraction.Entities;
using TLOverbookingApplication.WebClient;

namespace TLOverbookingApplication.RoomStayFactExtraction.Extractors
{
    // TODO перенести в проект application и сделать WebPmsDataExtractor
    public class RoomStayFactExtractor : IRoomStayFactExtractor
    {
        private readonly IWebPmsWebClient _webPmsWebClient;

        public RoomStayFactExtractor( IWebPmsWebClient webPmsWebClient )
        {
            _webPmsWebClient = webPmsWebClient;
        }

        public Task<RoomStayFactExtractionRS> GetRoomStayFactAsync( RoomStayFactExtractionRQ roomStayFactExtractionRQ )
        {
            // TODO вынести в конфиг
            string url = $"?providerId={roomStayFactExtractionRQ.ProviderId}&start={roomStayFactExtractionRQ.Start.ToShortDateString()}&end={roomStayFactExtractionRQ.End.ToShortDateString()}";
            try
            {
                return _webPmsWebClient.GetAsync<RoomStayFactExtractionRS>( url );
            }
            catch ( Exception ex )
            {
                // TODO сделать типизированный ex
                throw new Exception( ex.Message );
            }
        }
    }
}
