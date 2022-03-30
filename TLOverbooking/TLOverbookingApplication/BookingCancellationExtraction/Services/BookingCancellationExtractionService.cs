using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLOverbookingApplication.BookingCancellationExtraction.Entities;
using TLOverbookingApplication.WebClient;
using TLOverbookingDomain.BookingCancellation;

namespace TLOverbookingApplication.BookingCancellationExtraction.Services
{
    public class BookingCancellationExtractionService : IBookingCancellationExtractionService
    {
        private readonly IBookingCancellationService _bookingCancellationService;
        private readonly IWebPmsWebClient _webPmsWebClient;

        public BookingCancellationExtractionService( IBookingCancellationService bookingCancellationService, IWebPmsWebClient webPmsWebClient )
        {
            _bookingCancellationService = bookingCancellationService;
            _webPmsWebClient = webPmsWebClient;
        }

        public async Task<List<BookingCancellation>> ExtractBookingCancellationsAsync( long providerId, DateTime startDate, DateTime endDate )
        {
            GetBookingCancellationRQ request = new GetBookingCancellationRQ
            {
                ProviderId = providerId,
                StartDate = startDate.ToShortDateString(),
                EndDate = endDate.ToShortDateString()
            };
            GetBookingCancellationRS response = await _webPmsWebClient.GetBookingCancellationsAsync( request );

            if ( response?.BookingCancellations.Count == 0 )
            {
                return new List<BookingCancellation>();
            }

            List<BookingCancellation> extractedBookingCancellations = response.BookingCancellations.Select( ConvertBookingCancellationFromDto ).ToList();
            BookingCancellation[] storedBookingCancellations = await _bookingCancellationService.GetAsync( providerId, startDate, endDate );
            List<BookingCancellation> bookingCancellationsToSave = new List<BookingCancellation>();

            foreach ( BookingCancellation bookingCancellation in extractedBookingCancellations )
            {
                BookingCancellation storedBookingCancellation = storedBookingCancellations.FirstOrDefault( bc => bc.DateEnd == bookingCancellation.DateEnd
                    && bc.DateStart == bookingCancellation.DateStart
                    && bc.RoomTypeId == bookingCancellation.RoomTypeId );

                if ( storedBookingCancellations == null )
                {
                    bookingCancellationsToSave.Add( bookingCancellation );
                    continue;
                }

                storedBookingCancellation.Amount = bookingCancellation.Amount;
                bookingCancellationsToSave.Add( storedBookingCancellation );
            }

            _bookingCancellationService.AddRange( bookingCancellationsToSave );

            return bookingCancellationsToSave;
        }

        private BookingCancellation ConvertBookingCancellationFromDto( BookingCancellationDto bookingCancellationDto )
        {
            return new BookingCancellation
            {
                Amount = bookingCancellationDto.Amount,
                DateEnd = bookingCancellationDto.DateEnd,
                DateStart = bookingCancellationDto.DateStart,
                ProviderId = bookingCancellationDto.ProviderId,
                RoomTypeId = bookingCancellationDto.RoomTypeId
            };
        }
    }
}
