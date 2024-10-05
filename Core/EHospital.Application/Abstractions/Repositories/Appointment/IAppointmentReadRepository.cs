using EHospital.Domain.Entities;

namespace EHospital.Application.Abstractions.Repositories;

public interface IAppointmentReadRepository : IReadRepository<Appointment>
{
    Task<List<Appointment>> GetDoctorIdAsync(int doctorId);
    Task<List<Appointment>> GetPatientIdAsync(int patientId);
}
