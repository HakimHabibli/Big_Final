using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Persistence.Concretes.Repositories;

public class AppointmentReadRepository : ReadRepository<Appointment>, IAppointmentReadRepository
{
    public AppointmentReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
