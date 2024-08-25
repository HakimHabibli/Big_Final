using EHospital.Domain.Entities;

namespace EHospital.Application.Abstractions.Services;

public interface IAllergyService
{

    Task<List<Allergy>> GetAllAllergyAsync();
}