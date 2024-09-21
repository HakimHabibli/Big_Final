using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class EmergencyContactService : IEmergencyContactService
{
    //private readonly IEmergencyContactReadRepository _readRepo;
    //private readonly IEmergecyContactWriteRepository _writeRepo;
    private readonly IUnitOfWork _unitOfWork;

    public EmergencyContactService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}