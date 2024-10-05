using EHospital.Application.Abstractions.Repositories;
using EHospital.Concretes.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Concretes.Repositories;

public class AppointmentReadRepository : ReadRepository<Appointment>, IAppointmentReadRepository
{
    public AppointmentReadRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<List<Appointment>> GetDoctorIdAsync(int doctorId)
    {
        return await _appDbContext.Appointments
            .Where(a => a.DoctorId == doctorId)
            .ToListAsync();
    }

    public async Task<List<Appointment>> GetPatientIdAsync(int patientId)
    {
        return await _appDbContext.Appointments
            .Where(a => a.PatientId == patientId)
            .ToListAsync();
    }
}
