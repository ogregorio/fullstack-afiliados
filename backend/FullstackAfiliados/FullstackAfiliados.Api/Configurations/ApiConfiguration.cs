using FullstackAfiliados.Api.Middlewares;
using FullstackAfiliados.Infra.CrossCutting.Auth.Middlewares;
using FullstackAfiliados.Infra.Data.Context;

namespace FullstackAfiliados.Api.Configurations;

public static class ApiConfiguration
{
    public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UpdateDatabase();

        // global cors policy
        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        // global error handler
        app.UseMiddleware<ErrorHandlerMiddleware>();

        // Authentication
        app.UseAuthentication();

        // Authorization
        app.UseAuthorization();

        // Auth middleware
        app.UseAuthUser();

        // Routing
        app.UseRouting();

        // Mapping endpoints
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
            app.UseHttpsRedirection();
        }

        // SwaggerConfiguration middleware
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fullstack.Afiliados API");
        });

        return app;
    }
}