using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLOverbookingApplication.BookingCancellationExtraction.Entities;
using TLOverbookingApplication.BookingCancellationExtraction.Extractors;
using TLOverbookingDomain.BookingCancellation;

namespace TLOverbookingApplication.BookingCancellationExtraction.Services
{
    public class BookingCancellationExtractionService : IBookingCancellationExtractionService
    {
        private readonly IBookingCancellationService _bookingCancellationService;
        private readonly IBookingCancellationExtractor _bookingCancellationExtractor;

        public BookingCancellationExtractionService( IBookingCancellationService bookingCancellationService, IBookingCancellationExtractor bookingCancellationExtractor )
        {
            _bookingCancellationService = bookingCancellationService;
            _bookingCancellationExtractor = bookingCancellationExtractor;
        }

        public async Task ExtractBookingCancellationsAsync( long providerId, DateTime startDate, DateTime endDate )
        {
            BookingCancellationExtractionRQ request = new BookingCancellationExtractionRQ
            {
                ProviderId = providerId,
                StartDate = startDate,
                EndDate = endDate
            };
            BookingCancellationExtractionRS response = await _bookingCancellationExtractor.GetBookingCancellationsAsync( request );

            if ( response?.BookingCancellations.Count == 0 )
            {
                return;
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
