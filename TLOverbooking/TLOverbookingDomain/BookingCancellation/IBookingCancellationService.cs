using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TLOverbookingDomain.BookingCancellation
{
    public interface IBookingCancellationService
    {
        public Task<BookingCancellation[]> GetAsync( long providerId, DateTime startDate, DateTime endDate );

        public void AddRange( IEnumerable<BookingCancellation> entities );

        public void DeleteAllForProvider( long providerId );
    }
}
