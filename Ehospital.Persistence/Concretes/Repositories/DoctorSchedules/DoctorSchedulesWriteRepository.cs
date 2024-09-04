using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Persistence.Concretes.Repositories;

public class DoctorSchedulesWriteRepository : WriteRepository<DoctorSchedules>, IDoctorSchedulesWriteRepository
{
    public DoctorSchedulesWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}