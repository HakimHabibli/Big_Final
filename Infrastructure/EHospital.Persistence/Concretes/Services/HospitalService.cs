using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class HospitalService : IHospitalService
{
    private readonly IUnitOfWork _unitOfWork;

    public HospitalService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

}