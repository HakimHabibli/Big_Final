using EHospital.Domain.Entities;

namespace EHospital.Application.Abstractions.Repositories;

public interface IMedicalHistoryReadRepository : IReadRepository<MedicalHistory>
{
    Task<MedicalHistory> GetByPatientIdAsync(int patientId);

}
