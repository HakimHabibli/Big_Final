using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class PatientWriteRepository : WriteRepository<Patient>, IPatientWriteRepository
{
    public PatientWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
