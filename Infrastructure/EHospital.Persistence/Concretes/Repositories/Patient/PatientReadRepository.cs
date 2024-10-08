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

    //public async Task<Patient> GetBySerialNumberAsync(string serialNumber,)
    //{
    //    if (string.IsNullOrWhiteSpace(serialNumber))
    //        throw new ArgumentException("Serial number cannot be null or empty", nameof(serialNumber));

    //    return await _appDbContext.Patients
    //        .FirstOrDefaultAsync(p => p.SerialNumber == serialNumber);
    //}
    public async Task<Patient> GetBySerialNumberAsync(string serialNumber, bool asNoTracking = false)
    {
        if (string.IsNullOrWhiteSpace(serialNumber))
            throw new ArgumentException("Serial number cannot be null or empty", nameof(serialNumber));

        var query = _appDbContext.Patients.AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(p => p.SerialNumber == serialNumber);
    }


    public async Task<IEnumerable<Patient>> GetPatientsByHospitalIdAsync(int hospitalId)
    {
        return await _appDbContext.Patients
            .Where(p => p.HospitalId == hospitalId)
            .ToListAsync();
    }


}
