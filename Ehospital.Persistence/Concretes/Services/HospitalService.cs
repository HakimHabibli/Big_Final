using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class HospitalService : IHospitalService
{
    private readonly IHospitalReadRepository _readRepo;
    private readonly IHospitalWriteRepository _writeRepo;

    public HospitalService(IHospitalReadRepository readRepo, IHospitalWriteRepository writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }

}