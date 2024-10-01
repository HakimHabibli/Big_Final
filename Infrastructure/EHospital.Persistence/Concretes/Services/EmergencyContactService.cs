using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class EmergencyContactService : IEmergencyContactService
{
    //private readonly IEmergencyContactReadRepository _readRepo;
    //private readonly IEmergecyContactWriteRepository _writeRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmergencyContactService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}