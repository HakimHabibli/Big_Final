using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class DoctorSchedulesService : IDoctorSchedulesService
{

    private readonly IUnitOfWork _unitOfWork;

    public DoctorSchedulesService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}