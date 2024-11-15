﻿using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Concretes.Repositories;

public class DoctorReadRepository : ReadRepository<Doctor>, IDoctorReadRepository
{
    public DoctorReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsByHospitalIdAsync(int hospitalId)
    {
        return await _appDbContext.Doctors
            .Where(d => d.HospitalId == hospitalId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Patient>> GetPatientsByDoctorIdAsync(int doctorId)
    {
        return await _appDbContext.Patients
            .Include(p => p.ContactInfo)
            .Include(p => p.EmergencyContact)
            .Include(p => p.InsuranceDetails)
            .Include(p => p.Hospital)
            .Where(p => p.PatientDoctors.Any(pd => pd.DoctorId == doctorId))
            .ToListAsync();
    }
}
