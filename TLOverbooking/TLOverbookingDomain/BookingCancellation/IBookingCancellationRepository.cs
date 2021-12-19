using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLOverbookingDomain.Abstractions;

namespace TLOverbookingDomain.BookingCancellation
{
    public interface IBookingCancellationRepository : IBaseRepository<BookingCancellation>
    {
        Task<BookingCancellation[]> GetAllAsync( long providerId, DateTime startDate, DateTime endDate );
    }
}
