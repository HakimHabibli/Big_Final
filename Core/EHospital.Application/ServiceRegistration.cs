using EHospital.Application.Abstractions.Services;
using EHospital.Application.Mappers;
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
        // AutoMapper, MediatR, və FluentValidation qeydiyyatı
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DeactivateDoctorScheduleCommandHandler).Assembly);
        });
        services.AddValidatorsFromAssemblyContaining<HospitalCreateCommandRequestValidation>();
        services.AddFluentValidationAutoValidation();
       
        services.AddHttpClient();

        
    }
}
