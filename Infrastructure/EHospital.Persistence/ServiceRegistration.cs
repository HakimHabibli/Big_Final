﻿using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Concretes.Repositories;
using EHospital.Application.Concretes.Services;
using EHospital.Domain.Entities.Auth;
using EHospital.Persistence.Concretes;
using EHospital.Persistence.Concretes.Repositories;
using EHospital.Persistence.Concretes.Services;
using EHospital.Persistence.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace EHospital.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceService(this IServiceCollection services)
    {

        services.AddIdentity<AppUser, AppRole>
            (options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

             
            })
            .AddEntityFrameworkStores<AppDbContext>();//AddEntityFreameworkStores hansi dbde store olacaqsa onu bildiririk 
      
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
        services.AddScoped<IHospitalReadRepository, HospitalReadRepository>();
        services.AddScoped<IHospitalWriteRepository, HospitalWriteRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        #region Services
        services.AddScoped<IHospitalService, HospitalService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
        services.AddScoped<IInsuranceDetailsService, InsuranceDetailsService>();
        services.AddScoped<IEmergencyContactService, EmergencyContactService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IContactInfoService, ContactInfoService>();
        services.AddScoped<IAllergyService, AllergyService>();
        services.AddScoped<IPatientDoctorService, PatientsDoctorsService>();
        services.AddScoped<IDoctorSchedulesService, DoctorSchedulesService>();
        #endregion

    }

}
