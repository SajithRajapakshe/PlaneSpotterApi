using AutoMapper;
using PlaneSpotterBL.Services;
using PlaneSpotterDL.Repositories.AircraftRepository;

namespace PlaneSpotterApi.Extensions
{
    /// <summary>
    /// Dependency injection extension
    /// </summary>
    public static class CustomServicesExtension
    {
        public static void AddCustomServiceExtension(this IServiceCollection services)
        {
            services.AddTransient<IAircraftSpotterRepository, AircraftSpotterRepository>();
            services.AddTransient<IAircraftSpotterService, AircraftSpotterService>();
            services.AddTransient<IImageFileService, ImageFileService>();
        }
    }
}
