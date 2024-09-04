
using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Persistence.Concretes.Repositories;

public class HospitalWriteRepository : WriteRepository<Hospital>, IHospitalWriteRepository
{
    public HospitalWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}