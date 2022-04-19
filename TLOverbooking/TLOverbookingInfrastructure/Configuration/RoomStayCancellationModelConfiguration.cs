using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TLOverbookingDomain.RoomStayCancellation;

namespace TLOverbookingInfrastructure.Configuration
{
    public class RoomStayCancellationModelConfiguration : IEntityTypeConfiguration<RoomStayCancellationModel>
    {
        public void Configure( EntityTypeBuilder<RoomStayCancellationModel> builder )
        {
            builder.ToTable( nameof( RoomStayCancellationModel ) );
            builder.HasKey( bc => bc.Id );
            builder.Property( bc => bc.Id ).HasColumnName( "RoomStayCancellationModelId" );
        }
    }
}
