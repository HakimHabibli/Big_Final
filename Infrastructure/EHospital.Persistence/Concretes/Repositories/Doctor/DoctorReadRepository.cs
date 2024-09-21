using EHospital.Application.Abstractions.Repositories;
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

    public async Task<IEnumerable<Patient>> GetPatientsByDoctorIdAsync(int doctorId)
    {
        return await _appDbContext.Patients
            .Where(p => p.PatientDoctors.Any(pd => pd.DoctorId == doctorId))
            .ToListAsync();
    }
}
