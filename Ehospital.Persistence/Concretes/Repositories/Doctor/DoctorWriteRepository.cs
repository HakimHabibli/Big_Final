using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class DoctorWriteRepository : WriteRepository<Doctor>, IDoctorWriteRepository
{
    public DoctorWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
