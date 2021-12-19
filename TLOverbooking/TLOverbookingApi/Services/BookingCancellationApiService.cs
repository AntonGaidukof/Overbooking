using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLOverbookingApi.Dto.BookingCancellation;
using TLOverbookingApplication.BookingCancellationExtraction.Services;
using TLOverbookingDomain.Abstractions;
using TLOverbookingDomain.BookingCancellation;

namespace TLOverbookingApi.Services
{
    public class BookingCancellationApiService : IBookingCancellationApiService
    {
        private readonly IBookingCancellationService _bookingCancellationService;
        private readonly IBookingCancellationExtractionService _bookingCancellationExtractionService;
        private readonly IUnitOfWork _unitOfWork;

        public BookingCancellationApiService( 
            IBookingCancellationService bookingCancellationService,
            IBookingCancellationExtractionService bookingCancellationExtractionService,
            IUnitOfWork unitOfWork )
        {
            _bookingCancellationService = bookingCancellationService;
            _bookingCancellationExtractionService = bookingCancellationExtractionService;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> ExtractBookingCancellationsAsync( ExtractBookingCancellationsDto extractBookingCancellationsDto )
        {
            throw new NotImplementedException();
        }

        public async Task<BookingCancellationsDto> GetBookingCancellationsAsync( GetBookingCancellationDto request )
        {
            DateTime startDate;
            DateTime endDate;
            try
            {
                startDate = DateTime.Parse( request.StartDate );
                endDate = DateTime.Parse( request.EndDate );
            }
            catch ( Exception )
            {
                return null;
            }

            var bookingCancellations = await _bookingCancellationService.GetAsync( request.ProviderId, startDate, endDate );

            return new BookingCancellationsDto
            {
                BookingCancellations = bookingCancellations.Select( ConvertBookingCancellationToDto ).ToArray()
            };
        }

        public Task SaveBookingCancellationsAsync( BookingCancellationsDto bookingCancellationDtos )
        {
            List<BookingCancellation> bookingCancellations;
            try
            {
                bookingCancellations = bookingCancellationDtos.BookingCancellations.Select( ConvertBookingCancellationFromDto ).ToList();
            }
            catch ( Exception )
            {
                return Task.CompletedTask;
            }
            _bookingCancellationService.AddRange( bookingCancellations );
            return _unitOfWork.CommitAsync();
        }

        public Task DeleteAllProviderBookingCancellationsAsync( long providerId )
        {
            _bookingCancellationService.DeleteAllForProvider( providerId );
            return _unitOfWork.CommitAsync();
        }

        private BookingCancellationDto ConvertBookingCancellationToDto( BookingCancellation bookingCancellation )
        {
            return new BookingCancellationDto
            {
                Amount = bookingCancellation.Amount,
                EndDate = bookingCancellation.DateEnd.ToShortDateString(),
                StartDate = bookingCancellation.DateStart.ToShortDateString(),
                Id = bookingCancellation.Id,
                ProviderId = bookingCancellation.ProviderId,
                RoomTypeId = bookingCancellation.RoomTypeId
            };
        }

        private BookingCancellation ConvertBookingCancellationFromDto( BookingCancellationDto bookingCancellationDto )
        {
            return new BookingCancellation
            {
                Id = bookingCancellationDto.Id,
                Amount = bookingCancellationDto.Amount,
                DateEnd = DateTime.Parse( bookingCancellationDto.EndDate ),
                DateStart = DateTime.Parse( bookingCancellationDto.StartDate ),
                ProviderId = bookingCancellationDto.ProviderId,
                RoomTypeId = bookingCancellationDto.RoomTypeId
            };
        }
    }
}
