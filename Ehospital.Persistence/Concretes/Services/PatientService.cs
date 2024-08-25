using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class PatientService : IPatientService
{ 
    private readonly IPatientReadRepository _readRepo;
    private readonly IPatientWriteRepository _writeRepo;

    public PatientService(IPatientReadRepository readRepo, IPatientWriteRepository writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }
}
