using EHospital.Domain.Entities;

namespace EHospital.Application.Abstractions.Repositories;

public interface IDoctorReadRepository : IReadRepository<Doctor>
{
    Task<IEnumerable<Patient>> GetPatientsByDoctorIdAsync(int doctorId);

    Task<IEnumerable<Doctor>> GetDoctorsByHospitalIdAsync(int hospitalId);
    /*
     * IReadRepository daxili
      Task<IQueryable<T>> GetAllAsync(bool asNoTracking = false, params string[] includes);
    Task<T> GetByIdAsync(int id, params string[] includes);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false, params string[] includes);
     */

}
