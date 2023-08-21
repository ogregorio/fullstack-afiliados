using System.Reflection;
using FullstackAfiliados.Api.Bootstrap;
using FullstackAfiliados.Api.Configurations;
using FullstackAfiliados.Infra.CrossCutting.IoC;
using FullstackAfiliados.Infra.Data.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

namespace FullstackAfiliados.Api;

public class ControllerDiscoveryConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        Console.WriteLine($"Controller: {controller.ControllerType.Name}");
    }
}

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
        Console.WriteLine("Configuring: database");
        services.AddDbContext<DataContext>();
        services.AddScoped<DbContext, DataContext>();
        Console.WriteLine("Configuring: dependencies");
        services.InjectDependencies(Configuration);
        Console.WriteLine("Configuring: mediatR");
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.RegisterServicesFromAssemblyContaining<Startup>();
            cfg.Lifetime = ServiceLifetime.Scoped;
        });
        services.AddScoped<IMediator, Mediator>();
        Console.WriteLine("Configuring: automapper");
        services.CreateMapper();
        Console.WriteLine("Configuring: cors");
        services.CorsConfig();
        Console.WriteLine("Configuring: controllers");
        services.AddControllers();
        Console.WriteLine("Configuring: swagger documentation");
        services.GenDocumentation();
    }

    public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        Console.WriteLine("Configuring: api configuration");
        app.UseApiConfiguration(env);
        app.UseTypesBootstrap().Wait();
    }
}