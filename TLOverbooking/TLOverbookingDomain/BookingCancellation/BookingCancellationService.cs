using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TLOverbookingDomain.BookingCancellation
{
    public class BookingCancellationService : IBookingCancellationService
    {
        private readonly IBookingCancellationRepository _bookingCancellationRepository;

        public BookingCancellationService( IBookingCancellationRepository bookingCancellationRepository )
        {
            _bookingCancellationRepository = bookingCancellationRepository;
        }

        public void AddRange( IEnumerable<BookingCancellation> entities )
        {
            _bookingCancellationRepository.AddRange( entities );
        }

        public void DeleteAllForProvider( long providerId )
        {
            var entitiesToRemove = _bookingCancellationRepository.GetQuery().Where( e => e.ProviderId == providerId );
            _bookingCancellationRepository.RemoveRange( entitiesToRemove );
        }

        public Task<BookingCancellation[]> GetAsync( long providerId, DateTime startDate, DateTime endDate )
        {
            return _bookingCancellationRepository.GetAllAsync( providerId, startDate, endDate );
        }
    }
}
