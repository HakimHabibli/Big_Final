using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class EmergencyContactReadRepository : ReadRepository<EmergencyContact>, IEmergencyContactReadRepository
{
    public EmergencyContactReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
