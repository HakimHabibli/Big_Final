using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class MedicalHistoryService : IMedicalHistoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public MedicalHistoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
