using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class ContactInfoService : IContactInfoService
{
    private readonly IContactInfoReadRepository _readRepo;
    private readonly IContactInfoWriteRepository _writeRepo;

    public ContactInfoService(IContactInfoReadRepository readRepo, IContactInfoWriteRepository writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }
}
