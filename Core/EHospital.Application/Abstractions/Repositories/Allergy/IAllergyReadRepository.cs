namespace EHospital.Application.Abstractions.Repositories;

public interface IAllergyReadRepository : IReadRepository<Allergy>
{
    public Task<IEnumerable<Allergy>> GetAllergiesByPatientIdAsync(int patientId);
}
