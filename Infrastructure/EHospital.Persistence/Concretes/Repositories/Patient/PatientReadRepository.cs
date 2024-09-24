using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Concretes.Repositories;

public class PatientReadRepository : ReadRepository<Patient>, IPatientReadRepository
{
    public PatientReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Patient>> GetPatientsByHospitalIdAsync(int hospitalId)
    {
        return await _appDbContext.Patients
            .Where(p => p.HospitalId == hospitalId)
            .ToListAsync();
    }
}
