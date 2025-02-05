﻿using Microsoft.Extensions.DependencyInjection;
using TLOverbookingApplication.BookingCancellationExtraction.Services;
using TLOverbookingApplication.RoomStayCancellation.Services;
using TLOverbookingApplication.RoomStayFactExtraction.Convertors;
using TLOverbookingApplication.RoomStayFactExtraction.Services;
using TLOverbookingApplication.WebClient;
using TLOverbookingDomain.Abstractions;
using TLOverbookingDomain.BookingCancellation;
using TLOverbookingDomain.Provider;
using TLOverbookingDomain.RoomStayCancellation;
using TLOverbookingDomain.RoomStayFact;
using TLOverbookingInfrastructure.Foundation;
using TLOverbookingInfrastructure.Repositopries;
using TLOverbookingInfrastructure.WebClient;
using TLOverbookingML.RoomStayCancellation.Service;

namespace TLOverbookingInfrastructure.Injections
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAppDependencies( this IServiceCollection services )
        {
            // RoomStayFactExtraction
            services.AddScoped<IRoomStayFactConvertor, RoomStayFactConvertor>();
            services.AddScoped<IRoomStayFactExtractionService, RoomStayFactExtractionService>();

            //RoomStayFact
            services.AddScoped<IRoomStayFactRepository, RoomStayFactRepository>();
            services.AddScoped<IRoomStayFactService, RoomStayFactService>();

            //Provider
            services.AddScoped<IProviderPredictionModelRepository, ProviderPredictionModelRepository>();
            services.AddScoped<IProviderPredictionModelService, ProviderPredictionModelService>();
            
            // WebClient
            services.AddScoped<IWebPmsWebClient, WebPmsWebClient>();

            // BookingCancellation
            services.AddScoped<IBookingCancellationRepository, BookingCancellationRepository>();
            services.AddScoped<IBookingCancellationService, BookingCancellationService>();

            // BookingCancellationExtraction
            services.AddScoped<IBookingCancellationExtractionService, BookingCancellationExtractionService>();

            // Foundation
            services.AddScoped<IUnitOfWork, UnitOfWork<TLOverbookingDbContext>>();

            // RoomStayCancellation
            services.AddScoped<IRoomStayCancellationLearningProcessRepository, RoomStayCancellationLearningProcessRepository>();
            services.AddScoped<IRoomStayCancellationModelRepository, RoomStayCancellationModelRepository>();
            services.AddScoped<IRoomStayCancellationLearningProcessService, RoomStayCancellationLearningProcessService>();
            services.AddScoped<IRoomStayCancellationModelService, RoomStayCancellationModelService>();
            services.AddScoped<ILearningModelService, LearningModelService>();
            services.AddScoped<IMLModelService, MLModelService>();
            services.AddScoped<IPredictionService, PredictionService>();
            services.AddScoped<IRoomStayDataViewService, RoomStayDataViewService>();

            return services;
        }
    }
}
