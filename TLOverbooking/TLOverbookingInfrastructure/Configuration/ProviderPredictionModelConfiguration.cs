using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TLOverbookingDomain.Provider;

namespace TLOverbookingInfrastructure.Configuration
{
    public class ProviderPredictionModelConfiguration : IEntityTypeConfiguration<ProviderPredictionModel>
    {
        public void Configure( EntityTypeBuilder<ProviderPredictionModel> builder )
        {
            builder.ToTable( nameof( ProviderPredictionModel ) );
            builder.HasKey( ppm => ppm.Id );
            builder.Property( ppm => ppm.Id ).HasColumnName( "ProviderPredictionModelId" );
            builder.Property( ppm => ppm.Key ).HasMaxLength( 100 ).IsRequired();
        }
    }
}
