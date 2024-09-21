using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EHospital.Application;

public static class ServiceRegistration
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly);
        });//Mediatr Servisi burda add eləmək üçün  
    }
}
