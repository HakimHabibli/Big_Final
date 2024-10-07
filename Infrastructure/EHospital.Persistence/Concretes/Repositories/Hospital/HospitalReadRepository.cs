using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Exceptions;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Concretes.Repositories;

public class HospitalReadRepository : ReadRepository<Hospital>, IHospitalReadRepository
{
    public HospitalReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    public async Task<string> GetByNameAsync(string name)
    {
        var hospital = await _appDbContext.Hospitals
            .Where(h => h.Name == name)
            .Select(h => h.Name)  // Burada xəstəxananın adını seçirik
            .FirstOrDefaultAsync();

        if (hospital == null)
        {
            throw new NotFoundException("Hospital not found");
        }

        return hospital;  // Burada sadəcə xəstəxananın adını qaytarırıq
    }

}
