using EHospital.Application.Dtos.Entites.Allergy;

namespace EHospital.Application.Abstractions.Services;

public interface IAllergyService
{

    Task CreateAllergyAsync(AllergyCreateDto allergyCreateDto);
    Task UpdateAllergyAsync(AllergyUpdateDto allergyUpdateDto);
    Task DeleteAllergyAsync(AllergyDeleteDto allergyDeleteDto);
    Task<IEnumerable<AllergyReadDto>> GetAllAllergiesAsync();
    Task<AllergyReadDto> GetAllergyByIdAsync(int id);
    Task<IEnumerable<AllergyReadDto>> GetAllergiesByPatientIdAsync(int patientId);

}
