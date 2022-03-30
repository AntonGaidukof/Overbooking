using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using TLOverbookingApplication.Configuration;

namespace TLOverbookingInfrastructure.Foundation
{
    public class DesignTimeRepositoryContextFactory : IDesignTimeDbContextFactory<TLOverbookingDbContext>
    {
        public TLOverbookingDbContext CreateDbContext( string[] args )
        {
            // HostingEnvironment hostingEnvironment = new HostingEnvironment();
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
                //.AddJsonFile( $"appsettings.{hostingEnvironment.EnvironmentName}.json" );

            var config = builder.Build();
            var connectionString = config.GetConnectionString( ApplicationConfiguration.DBConnectionString );
            var optionsBuilder = new DbContextOptionsBuilder<TLOverbookingDbContext>();
            optionsBuilder.UseSqlServer( connectionString );

            return new TLOverbookingDbContext( optionsBuilder.Options );
        }
    }
}
