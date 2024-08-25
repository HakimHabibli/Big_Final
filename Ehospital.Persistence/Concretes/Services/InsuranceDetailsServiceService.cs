using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class InsuranceDetailsServiceService : IInsuranceDetailsService
{
    private readonly IInsuranceDetailsReadRepository _readRepo;
    private readonly IInsuranceDetailsWriteRepository _writeRepo;

    public InsuranceDetailsServiceService(IInsuranceDetailsWriteRepository writeRepo, IInsuranceDetailsReadRepository readRepo)
    {
        _writeRepo = writeRepo;
        _readRepo = readRepo;
    }
}
