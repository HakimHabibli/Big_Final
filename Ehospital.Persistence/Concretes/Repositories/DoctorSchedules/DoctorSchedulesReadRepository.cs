using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Persistence.Concretes.Repositories;

public class DoctorSchedulesReadRepository : ReadRepository<DoctorSchedules>, IDoctorSchedulesReadRepository
{
    public DoctorSchedulesReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
