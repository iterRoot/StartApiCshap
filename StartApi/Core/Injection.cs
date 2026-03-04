using System.Reflection;
using NSwag.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
namespace StartApi.Core;

public static class DependencyInjection
{
    public static void AddMiddleWare(this IApplicationBuilder app)
    {
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        app.AddError();
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        if (env != "Development") return;
        app.UseOpenApi();
        app.UseSwaggerUi();
    }

    public static void AddInjection(this IServiceCollection service)
    {
        _assemblyInjection(service, "Service");
        _assemblyInjection(service, "SingletonService");
        _assemblyInjection(service, "Repository");
        service.AddAutoMapper(Assembly.GetExecutingAssembly());
        service.AddMyCors();
        // service.AddMyAuthentication();
        service.AddMySwagger();
        service.AddControllers();
    }

    private static void _assemblyInjection(IServiceCollection service, string subFix)
    {
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(a => a.Name.EndsWith(subFix) && a is { IsAbstract: false, IsInterface: false })
            .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
            .ToList()
            .ForEach(typesToRegister =>
            {
                if (subFix.Contains("Singleton"))
                {
                    typesToRegister.serviceTypes.ForEach(typeToRegister =>
                        service.AddSingleton(typeToRegister, typesToRegister.assignedType));
                }
                else
                {
                    typesToRegister.serviceTypes.ForEach(typeToRegister =>
                        service.AddScoped(typeToRegister, typesToRegister.assignedType));
                }
            });
    }
}