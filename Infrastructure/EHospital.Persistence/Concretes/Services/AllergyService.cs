using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class AllergyService : IAllergyService
{
    private readonly IUnitOfWork _unitOfWork;

    public AllergyService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //public override async Task<List<Allergy>> GetAllAllergyAsync()
    //{
    //    List<Allergy> allergies = await _readRepo.GetAll().ToListAsync();
    //    return allergies;
    //}

}
