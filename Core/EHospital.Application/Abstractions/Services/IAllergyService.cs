using EHospital.Application.Dtos.Entites.Allergy;

namespace EHospital.Application.Abstractions.Services;

public interface IAllergyService
{
    public virtual async Task<List<AllergyDto>> GetAllAllergyAsync()
    {
        return default;
    }
}
