using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Application.Concretes.Repositories;

public class MedicalHistoryWriteRepository : WriteRepository<MedicalHistory>, IMedicalHistoryWriteRepository
{
    public MedicalHistoryWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
