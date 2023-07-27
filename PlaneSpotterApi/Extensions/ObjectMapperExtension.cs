using AutoMapper;
using PlaneSpotterBL.Mappers;
using PlaneSpotterBL.Services;
using PlaneSpotterDL.Repositories.AircraftRepository;

namespace PlaneSpotterApi.Extensions
{
    /// <summary>
    /// Extension for adding object mapper configuration to service pipeline.
    /// </summary>
    public static class ObjectMapperExtension
    {
        public static void AddObjectMappereExtension(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ObjectMapper());
            });

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
