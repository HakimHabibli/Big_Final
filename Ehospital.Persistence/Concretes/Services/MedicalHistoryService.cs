using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class MedicalHistoryService : IMedicalHistoryService
{
    private readonly IMedicalHistoryReadRepository _readRepo;
    private readonly IMedicalHistoryWriteRepository _writeRepo;

    public MedicalHistoryService(IMedicalHistoryWriteRepository writeRepo, IMedicalHistoryReadRepository readRepo)
    {
        _writeRepo = writeRepo;
        _readRepo = readRepo;
    }
}
