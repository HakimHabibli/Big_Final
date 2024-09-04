using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EHospital.Application;

public static class ServiceRegistration
{
    public static void AddApplicationSerivice(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
