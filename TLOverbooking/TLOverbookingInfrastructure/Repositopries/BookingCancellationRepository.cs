using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLOverbookingDomain.BookingCancellation;
using TLOverbookingInfrastructure.Foundation;

namespace TLOverbookingInfrastructure.Repositopries
{
    public class BookingCancellationRepository : BaseRepository<BookingCancellation>, IBookingCancellationRepository
    {
        public BookingCancellationRepository( TLOverbookingDbContext dbContext )
            :base( dbContext )
        {
        }

        public Task<BookingCancellation[]> GetAllAsync( long providerId, DateTime startDate, DateTime endDate )
        {
            return Entities.Where( bc => bc.ProviderId == providerId && bc.DateStart >= startDate && bc.DateEnd <= endDate ).ToArrayAsync();
        }
    }
}
