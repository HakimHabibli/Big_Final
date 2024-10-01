
using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Concretes.Repositories;

public class AllergyReadRepository : ReadRepository<Allergy>, IAllergyReadRepository
{
    public AllergyReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    public async Task<IEnumerable<Allergy>> GetAllergiesByPatientIdAsync(int patientId)
    {
        return await _appDbContext.Allergies.Where(a => a.PatientId == patientId).ToListAsync();
    }
}
