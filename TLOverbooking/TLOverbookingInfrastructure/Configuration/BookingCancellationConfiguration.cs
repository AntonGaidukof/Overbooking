using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TLOverbookingDomain.BookingCancellation;

namespace TLOverbookingInfrastructure.Configuration
{
    public class BookingCancellationConfiguration : IEntityTypeConfiguration<BookingCancellation>
    {
        public void Configure( EntityTypeBuilder<BookingCancellation> builder )
        {
            builder.ToTable( nameof( BookingCancellation ) );
            builder.HasKey( bc => bc.Id );
            builder.Property( bc => bc.Id ).HasColumnName( "BookingCancellationName" );
        }
    }
}
