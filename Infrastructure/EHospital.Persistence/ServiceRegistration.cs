using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Concretes.Repositories;
using EHospital.Application.Concretes.Services;
using EHospital.Persistence.Concretes;
using EHospital.Persistence.Concretes.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EHospital.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceService(this IServiceCollection services)
    {


        #region Repositories
        services.AddScoped<IPatientReadRepository, PatientReadRepository>();
        services.AddScoped<IPatientWriteRepository, PatientWriteRepository>();

        services.AddScoped<IAppointmentReadRepository, AppointmentReadRepository>();
        services.AddScoped<IAppointmentWriteRepository, AppointmentWriteRepository>();

        services.AddScoped<IMedicalHistoryReadRepository, MedicalHistoryReadRepository>();
        services.AddScoped<IMedicalHistoryWriteRepository, MedicalHistoryWriteRepository>();

        services.AddScoped<IInsuranceDetailsReadRepository, InsuranceDetailsReadRepository>();
        services.AddScoped<IInsuranceDetailsWriteRepository, InsuranceDetailsWriteRepository>();

        services.AddScoped<IEmergencyContactReadRepository, EmergencyContactReadRepository>();
        services.AddScoped<IEmergecyContactWriteRepository, EmergencyContactWriteRepository>();

        services.AddScoped<IDoctorReadRepository, DoctorReadRepository>();
        services.AddScoped<IDoctorWriteRepository, DoctorWriteRepository>();

        services.AddScoped<IContactInfoReadRepository, ContactInfoReadRepository>();
        services.AddScoped<IContactInfoWriteRepository, ContactInfoWriteRepository>();

        services.AddScoped<IAllergyReadRepository, AllergyReadRepository>();
        services.AddScoped<IAllergyWriteRepository, AllergyWriteRepository>();

        services.AddScoped<IDoctorSchedulesReadRepository, DoctorSchedulesReadRepository>();
        services.AddScoped<IDoctorSchedulesWriteRepository, DoctorSchedulesWriteRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        #region Services

        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
        services.AddScoped<IInsuranceDetailsService, InsuranceDetailsService>();
        services.AddScoped<IEmergencyContactService, EmergencyContactService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IContactInfoService, ContactInfoService>();
        services.AddScoped<IAllergyService, AllergyService>();
        services.AddScoped<IDoctorSchedulesService, DoctorSchedulesService>();
        #endregion

    }

}
