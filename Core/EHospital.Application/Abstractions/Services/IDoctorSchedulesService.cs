

namespace EHospital.Application.Abstractions.Services;

public interface IDoctorSchedulesService
{
    Task CreateDoctorSchedulesAsync(DoctorSchedulesCreateDto doctorCreateDto);
    Task UpdateDoctorSchedulesAsync(DoctorSchedulesUpdateDto doctorUpdateDto);
    Task DeleteDoctorSchedulesAsync(DoctorSchedulesDeleteDto doctorDeleteDto);

    Task<IEnumerable<DoctorSchedulesReadDto>> GetAllDoctorSchedulesAsync();
    Task<DoctorSchedulesReadDto> GetDoctorSchedulesByIdAsync(int scheduleId);
    Task<DoctorReadDto> GetDoctorSchedulesByDoctorNameAsync(string doctorName);
    Task<IEnumerable<DoctorSchedulesReadDto>> GetActiveDoctorSchedulesAsync();

}