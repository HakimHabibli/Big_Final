
using EHospital.Application.Abstractions.Repositories;
using EHospital.Domain.Entities;
using System.Linq.Expressions;

public interface IUserDeactivatedScheduleReadRepository : IReadRepository<UserDeactivatedSchedule>
{

    Task<IEnumerable<UserDeactivatedSchedule>> GetWhereAsync(Expression<Func<UserDeactivatedSchedule, bool>> predicate, params string[] includes);
    Task<UserDeactivatedSchedule> GetSingleAsync(Expression<Func<UserDeactivatedSchedule, bool>> predicate);

}
