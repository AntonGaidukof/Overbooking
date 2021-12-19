using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TLOverbookingInfrastructure.Foundation
{
    public class DesignTimeRepositoryContextFactory : IDesignTimeDbContextFactory<TLOverbookingDbContext>
    {
        public TLOverbookingDbContext CreateDbContext( string[] args )
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath( Directory.GetCurrentDirectory() )
                .AddJsonFile( "appsettings.json" );

            var config = builder.Build();
            var connectionString = config.GetConnectionString( "TLOverbookingConnection" );
            var optionsBuilder = new DbContextOptionsBuilder<TLOverbookingDbContext>();
            optionsBuilder.UseSqlServer( connectionString );

            return new TLOverbookingDbContext( optionsBuilder.Options );
        }
    }
}
