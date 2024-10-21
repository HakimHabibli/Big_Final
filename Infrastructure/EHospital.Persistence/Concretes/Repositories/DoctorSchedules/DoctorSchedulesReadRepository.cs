using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Exceptions;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EHospital.Persistence.Concretes.Repositories;

public class DoctorSchedulesReadRepository : ReadRepository<DoctorSchedules>, IDoctorSchedulesReadRepository
{
    public DoctorSchedulesReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<DoctorSchedules> GetSingleAsync(Expression<Func<DoctorSchedules, bool>> predicate)
    {
        var schedule = await _appDbContext.Set<DoctorSchedules>()
            .Where(predicate)
            .FirstOrDefaultAsync();  

        if (schedule == null)
        {
            throw new NotFoundException("Doctor schedule not found");
        }

        return schedule;  
    }

   
    public async Task<IEnumerable<DoctorSchedules>> GetWhereAsync(Expression<Func<DoctorSchedules, bool>> predicate, string includeProperties = "")
    {
        IQueryable<DoctorSchedules> query = _appDbContext.Set<DoctorSchedules>();

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        var schedules = await query.Where(predicate).ToListAsync();  

        if (schedules == null || !schedules.Any())
        {
            throw new NotFoundException("No doctor schedules found for the given criteria");
        }

        return schedules;  
    }
}
