using System;
using System.Threading.Tasks;
using TLOverbookingApplication.BookingCancellationExtraction.Entities;
using TLOverbookingApplication.WebClient;

namespace TLOverbookingApplication.BookingCancellationExtraction.Extractors
{
    public class BookingCancellationExtractor : IBookingCancellationExtractor
    {
        private readonly IWebPmsWebClient _webPmsWebClient;

        public BookingCancellationExtractor( IWebPmsWebClient webPmsWebClient )
        {
            _webPmsWebClient = webPmsWebClient;
        }

        public Task<BookingCancellationExtractionRS> GetBookingCancellationsAsync( BookingCancellationExtractionRQ bookingCancellationExtractionRQ )
        {
            string url = $"?providerId={bookingCancellationExtractionRQ.ProviderId}&start={bookingCancellationExtractionRQ.StartDate.ToShortDateString()}&end={bookingCancellationExtractionRQ.EndDate.ToShortDateString()}";
            try
            {
                return _webPmsWebClient.GetAsync<BookingCancellationExtractionRS>( url );
            }
            catch ( Exception ex )
            {
                // TODO сделать типизированный ex
                throw new Exception( ex.Message );
            }
        }
    }
}
