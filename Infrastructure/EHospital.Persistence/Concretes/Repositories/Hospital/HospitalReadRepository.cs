using EHospital.Application.Abstractions.Repositories;
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
    public async Task<Hospital> GetByNameAsync(string name)
    {

        var hospitalName = await _appDbContext.Hospitals
            .FirstOrDefaultAsync(h => h.Name == name);
        if (hospitalName == null) throw new Exception("Hospital not found");

        return hospitalName;
    }

}
