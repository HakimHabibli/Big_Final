using EHospital.Application.Validators.Hospital;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EHospital.Application;

public static class ServiceRegistration
{
    public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        // AutoMapper qeydiyyatı
        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        services.AddSingleton<ILogService, MongoLogService>();


        // MediatR qeydiyyatı
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly);
        });

        // FluentValidation validasiyaları qeydiyyatdan keçirmək
        services.AddValidatorsFromAssemblyContaining<HospitalCreateCommandRequestValidation>();

        // FluentValidation avtomatik validasiyanı qeydiyyatdan keçirmək
        services.AddFluentValidationAutoValidation();
    }
}
