using EHospital.Domain.Entities;

namespace EHospital.Application.Abstractions.Repositories;

public interface IDoctorReadRepository : IReadRepository<Doctor>
{
    Task<IEnumerable<Patient>> GetPatientsByDoctorIdAsync(int doctorId);

    Task<IEnumerable<Doctor>> GetDoctorsByHospitalIdAsync(int hospitalId);

}
