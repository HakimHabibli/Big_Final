using EHospital.Application.Dtos.Entites.DoctorSchedules;
using EHospital.Domain.Entities;

namespace EHospital.Application.Abstractions.Services;

public interface IUserDeactivatedScheduleService
{

    public Task<List<ActiveDoctorScheduleReadDto>> GetActiveDoctorSchedulesAsync();
    public Task<List<UserDeactivatedScheduleReadDto>> GetUserDeactivatedSchedulesAsync(int userId);
    public Task<bool> DeactivateDoctorScheduleAsync(UserScheduleDeactivateDto dto); 
    public Task<bool> ReactivateDoctorScheduleAsync(UserScheduleReactivateDto dto); 

}