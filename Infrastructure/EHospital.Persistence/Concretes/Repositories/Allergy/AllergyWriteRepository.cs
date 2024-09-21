
using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class AllergyWriteRepository : WriteRepository<Allergy>, IAllergyWriteRepository
{
    public AllergyWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
