using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EHospital.Persistence.Concretes.Repositories.NewFolder;

public class UserDeactivatedScheduleReadRepository : ReadRepository<UserDeactivatedSchedule>, IUserDeactivatedScheduleReadRepository
{
    public UserDeactivatedScheduleReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }


    public async Task<IEnumerable<UserDeactivatedSchedule>> GetWhereAsync(Expression<Func<UserDeactivatedSchedule, bool>> predicate, params string[] includes)
    {
        var query = _appDbContext.UserDeactivatedSchedules.AsQueryable();
        foreach (var includeProperty in includes)
        {
            query = query.Include(includeProperty);
        }
        return await query
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<UserDeactivatedSchedule> GetSingleAsync(Expression<Func<UserDeactivatedSchedule, bool>> predicate)
    {
        return await _appDbContext.UserDeactivatedSchedules.FirstOrDefaultAsync(predicate);
    }
}
