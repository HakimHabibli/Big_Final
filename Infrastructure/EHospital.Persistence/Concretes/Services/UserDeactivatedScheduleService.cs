using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using EHospital.Domain.Entities;

public class UserDeactivatedScheduleService : IUserDeactivatedScheduleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserDeactivatedScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    
    public async Task<List<ActiveDoctorScheduleReadDto>> GetActiveDoctorSchedulesAsync()
    {
        var activeSchedules = await _unitOfWork.DoctorSchedulesReadRepository
            .GetWhereAsync(schedule => schedule.IsActive, includeProperties: "Doctor");

        return _mapper.Map<List<ActiveDoctorScheduleReadDto>>(activeSchedules);
    }

  
    public async Task<List<UserDeactivatedScheduleReadDto>> GetUserDeactivatedSchedulesAsync(int userId)
    {
        var deactivatedSchedules = await _unitOfWork.UserDeactivatedScheduleReadRepository
            .GetWhereAsync(schedule => schedule.UserId == userId, includeProperties: "DoctorSchedule");

        return _mapper.Map<List<UserDeactivatedScheduleReadDto>>(deactivatedSchedules);
    }

    
    public async Task<bool> DeactivateDoctorScheduleAsync(UserScheduleDeactivateDto dto)
    {
        var doctorSchedule = await _unitOfWork.DoctorSchedulesReadRepository
            .GetSingleAsync(schedule => schedule.Id == dto.ScheduleId && schedule.IsActive);

        if (doctorSchedule == null)
            throw new KeyNotFoundException($"Doctor schedule with ID {dto.ScheduleId} not found or already deactivated.");

        var deactivatedSchedule = new UserDeactivatedSchedule
        {
            DoctorScheduleId = doctorSchedule.Id,
            UserId = dto.UserId,
            DeactivatedAt = DateTime.UtcNow
        };

        await _unitOfWork.UserDeactivatedScheduleWriteRepository.CreateAsync(deactivatedSchedule);

        doctorSchedule.IsActive = false;
        await _unitOfWork.DoctorSchedulesWriteRepository.UpdateAsync(doctorSchedule);

        return true;
    }

   
    public async Task<bool> ReactivateDoctorScheduleAsync(UserScheduleReactivateDto dto)
    {
        var deactivatedSchedule = await _unitOfWork.UserDeactivatedScheduleReadRepository
            .GetSingleAsync(schedule => schedule.DoctorScheduleId == dto.ScheduleId && schedule.UserId == dto.UserId);

        if (deactivatedSchedule == null)
            throw new KeyNotFoundException($"Deactivated schedule with ID {dto.ScheduleId} and User ID {dto.UserId} not found.");

        var doctorSchedule = await _unitOfWork.DoctorSchedulesReadRepository.GetSingleAsync(schedule => schedule.Id == dto.ScheduleId);

        if (doctorSchedule == null)
            throw new KeyNotFoundException($"Doctor schedule with ID {dto.ScheduleId} not found.");

        doctorSchedule.IsActive = true;
        await _unitOfWork.DoctorSchedulesWriteRepository.UpdateAsync(doctorSchedule);

        await _unitOfWork.UserDeactivatedScheduleWriteRepository.DeleteAsync(deactivatedSchedule);

        return true;
    }
}
