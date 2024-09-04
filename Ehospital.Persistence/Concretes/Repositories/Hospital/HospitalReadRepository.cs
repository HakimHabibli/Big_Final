using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Persistence.Concretes.Repositories;

public class HospitalReadRepository : ReadRepository<Hospital>, IHospitalReadRepository
{
    public HospitalReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }


}
