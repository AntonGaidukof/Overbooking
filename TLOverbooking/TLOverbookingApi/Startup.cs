using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TLOverbookingApi.Services;
using TLOverbookingInfrastructure.Foundation;
using TLOverbookingInfrastructure.Injections;

namespace TLOverbookingApi
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {

            services.AddControllers();
            services.AddAppDependencies();
            services.AddScoped<IRoomStayFactApiService, RoomStayFactApiService>();
            services.AddScoped<IBookingCancellationApiService, BookingCancellationApiService>();
            services.AddSwaggerGen( c =>
             {
                 c.SwaggerDoc( "v1", new OpenApiInfo { Title = "TLOverbookingApi", Version = "v1" } );
             } );
            services.AddDbContext<TLOverbookingDbContext>( c =>
                c.UseSqlServer( Configuration.GetConnectionString( "TLOverbookingConnection" ) )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI( c => c.SwaggerEndpoint( "/swagger/v1/swagger.json", "TLOverbookingApi v1" ) );
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapControllers();
             } );
        }
    }
}
