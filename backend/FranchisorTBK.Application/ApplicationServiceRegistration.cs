using FranchisorTBK.Application.Interfaces;
using FranchisorTBK.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace FranchisorTBK.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IKpiService, KpiService>();
        return services;
    }
}
