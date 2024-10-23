namespace EHospital.Application.Abstractions.Repositories;

public interface IDoctorSchedulesReadRepository : IReadRepository<DoctorSchedules> 
{
    Task<IEnumerable<DoctorSchedules>> GetWhereAsync(Expression<Func<DoctorSchedules, bool>> predicate, string includeProperties = "");
    Task<DoctorSchedules> GetSingleAsync(Expression<Func<DoctorSchedules, bool>> predicate);

}

