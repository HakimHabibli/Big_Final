using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Persistence.Concretes.Repositories.NewFolder;

public class UserDeactivatedScheduleWriteRepository : WriteRepository<UserDeactivatedSchedule>, IUserDeactivatedScheduleWriteRepository
{
    public UserDeactivatedScheduleWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}