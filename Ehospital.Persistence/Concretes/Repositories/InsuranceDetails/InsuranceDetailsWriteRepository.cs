using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class InsuranceDetailsWriteRepository : WriteRepository<InsuranceDetails>, IInsuranceDetailsWriteRepository
{
    public InsuranceDetailsWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
