using AutoMapper;
using FullstackAfiliados.Application.Helpers.AutoMapper;

namespace FullstackAfiliados.Api.Configurations;

public static class AutoMapperConfig
{
    public static IServiceCollection CreateMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.AddProfile<AutoMapperProfile>();
        });
        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }
}