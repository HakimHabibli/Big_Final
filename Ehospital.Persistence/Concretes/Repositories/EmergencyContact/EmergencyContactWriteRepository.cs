using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class EmergencyContactWriteRepository : WriteRepository<EmergencyContact>, IEmergecyContactWriteRepository
{
    public EmergencyContactWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
