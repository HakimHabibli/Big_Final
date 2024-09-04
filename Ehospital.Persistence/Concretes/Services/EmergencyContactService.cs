using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class EmergencyContactService : IEmergencyContactService
{
    private readonly IEmergencyContactReadRepository _readRepo;
    private readonly IEmergecyContactWriteRepository _writeRepo;

    public EmergencyContactService(IEmergencyContactReadRepository readRepo, IEmergecyContactWriteRepository writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }
}