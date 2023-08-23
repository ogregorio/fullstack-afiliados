using AutoMapper;
using FullstackAfiliados.Application.Helpers.AutoMapper;

namespace FullstackAfiliados.Tests.Factory;

public static class MapperFactory
{
    public static IMapper GetMapperFactory()
    {
        var mapperFactory = new MapperConfiguration(cfg =>
        {
            cfg.AllowNullDestinationValues = true;
            cfg.AllowNullCollections = true;

            cfg.DisableConstructorMapping();

            cfg.AddProfile(new AutoMapperProfile());
        });

        return mapperFactory.CreateMapper();
    }
}