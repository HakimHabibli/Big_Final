using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class ContactInfoService : IContactInfoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactInfoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
