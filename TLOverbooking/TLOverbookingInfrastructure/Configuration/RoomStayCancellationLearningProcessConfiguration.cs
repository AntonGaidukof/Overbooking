using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TLOverbookingDomain.RoomStayCancellation;

namespace TLOverbookingInfrastructure.Configuration
{
    public class RoomStayCancellationLearningProcessConfiguration : IEntityTypeConfiguration<RoomStayCancellationLearningProcess>
    {
        public void Configure( EntityTypeBuilder<RoomStayCancellationLearningProcess> builder )
        {
            builder.ToTable( nameof( RoomStayCancellationLearningProcess ) );
            builder.HasKey( bc => bc.Id );
            builder.Property( bc => bc.Id ).HasColumnName( "RoomStayCancellationLearningProcessId" );
        }
    }
}
