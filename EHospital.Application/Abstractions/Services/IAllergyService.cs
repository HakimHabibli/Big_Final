using EHospital.Application.Dtos.Entites.Allergy;

namespace EHospital.Application.Abstractions.Services;

public interface IAllergyService
{

    Task<List<AllergyDto>> GetAllAllergyAsync();
}
