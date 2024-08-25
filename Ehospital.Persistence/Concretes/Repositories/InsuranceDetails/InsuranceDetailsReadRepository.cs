using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class InsuranceDetailsReadRepository : ReadRepository<InsuranceDetails>, IInsuranceDetailsReadRepository
{
    public InsuranceDetailsReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
