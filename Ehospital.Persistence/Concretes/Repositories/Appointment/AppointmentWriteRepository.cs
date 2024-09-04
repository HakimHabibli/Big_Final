using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;

namespace EHospital.Persistence.Concretes.Repositories;

public class AppointmentWriteRepository : WriteRepository<Appointment>, IAppointmentWriteRepository
{
    public AppointmentWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
