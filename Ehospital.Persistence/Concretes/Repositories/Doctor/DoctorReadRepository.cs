using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class DoctorReadRepository : ReadRepository<Doctor>, IDoctorReadRepository
{
    public DoctorReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
