using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Abstractions.Services;
using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Concretes.Services;

public class AllergyService : IAllergyService
{
    private readonly IAllergyReadRepository _readRepo;
    private readonly IAllergyWriteRepository _writeRepo;

    public AllergyService(IAllergyReadRepository readRepo, IAllergyWriteRepository writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }

    public async Task<List<Allergy>> GetAllAllergyAsync()
    {
        List<Allergy> allergies = await _readRepo.GetAll().ToListAsync();
        return allergies;
    }
}