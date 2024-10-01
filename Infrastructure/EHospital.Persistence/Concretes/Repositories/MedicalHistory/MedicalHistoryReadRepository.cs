using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Concretes.Repositories;

public class MedicalHistoryReadRepository : ReadRepository<MedicalHistory>, IMedicalHistoryReadRepository
{
    public MedicalHistoryReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<MedicalHistory> GetByPatientIdAsync(int patientId)
    {
        if (patientId <= 0)
            throw new ArgumentException("PatientId must be greater than zero", nameof(patientId));

        return await _appDbContext.MedicalHistories
            .FirstOrDefaultAsync(mh => mh.PatientId == patientId);

    }
}
