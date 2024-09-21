using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;
namespace EHospital.Application.Concretes.Repositories;

public class PatientReadRepository : ReadRepository<Patient>, IPatientReadRepository
{
    public PatientReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
