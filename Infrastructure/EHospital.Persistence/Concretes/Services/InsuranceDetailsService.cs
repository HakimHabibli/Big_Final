using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class InsuranceDetailsService : IInsuranceDetailsService
{
    private readonly IUnitOfWork _unitOfWork;

    public InsuranceDetailsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
