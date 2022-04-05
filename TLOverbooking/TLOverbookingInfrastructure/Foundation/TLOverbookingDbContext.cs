using Microsoft.EntityFrameworkCore;
using TLOverbookingInfrastructure.Configuration;

namespace TLOverbookingInfrastructure.Foundation
{
    public class TLOverbookingDbContext : DbContext
    {
        public TLOverbookingDbContext( DbContextOptions<TLOverbookingDbContext> options ) 
            : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            builder.ApplyConfiguration( new ProviderPredictionModelConfiguration() );
            builder.ApplyConfiguration( new RoomStayFactConfiguration() );
            builder.ApplyConfiguration( new BookingCancellationConfiguration() );
            builder.ApplyConfiguration( new RoomStayCancellationLearningProcessConfiguration() );
        }
    }
}
