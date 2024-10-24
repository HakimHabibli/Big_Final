namespace EHospital.Application.Abstractions.Services;

public interface IAppointmentService
{
    Task CreateAppointmentAsync(AppointmentCreateDto appointmentCreateDto);
    Task UpdateAppointmentAsync(AppointmentUpdateDto appointmentUpdateDto);
    Task DeleteAppointmentAsync(AppointmentDeleteDto appointmentDeleteDto);
    Task<List<AppointmentReadDto>> GetAppointmentsByDoctorAsync(int doctorId); // Həkimin rezervləri
    Task<List<AppointmentReadDto>> GetAllAppointmentAsync();
    Task<List<AppointmentReadDto>> GetAppointmentsByPatientAsync(int patientId); // Xəstənin rezervləri
    Task<AppointmentReadDto> GetByIdAppointmentAsync(int id);
}