using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TLOverbookingDomain.RoomStayFact;

namespace TLOverbookingInfrastructure.Configuration
{
    public class RoomStayFactConfiguration : IEntityTypeConfiguration<RoomStayFact>
    {
        public void Configure( EntityTypeBuilder<RoomStayFact> builder )
        {
            builder.ToTable( nameof( RoomStayFact ) );
            builder.HasKey( rsf => rsf.Id );
            builder.Property( rsf => rsf.Id ).HasColumnName( "RoomStayFactId" );
        }
    }
}
