using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using EHospital.Domain.Entities;

namespace EHospital.Application.Concretes.Services;

public class DoctorSchedulesService : IDoctorSchedulesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DoctorSchedulesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateDoctorSchedulesAsync(DoctorSchedulesCreateDto doctorSchedulesCreateDto)
    {
        var doctorSchedule = _mapper.Map<DoctorSchedules>(doctorSchedulesCreateDto);

        await _unitOfWork.DoctorSchedulesWriteRepository.CreateAsync(doctorSchedule);

    }
    public async Task<DoctorSchedulesReadDto> GetDoctorSchedulesByIdAsync(int scheduleId)
    {
        var schedule = await _unitOfWork.DoctorSchedulesReadRepository.GetByIdAsync(scheduleId,includes:"Doctor");
        if (schedule == null) throw new KeyNotFoundException("Doctor Schedules not found");

        var scheduleDto = _mapper.Map<DoctorSchedulesReadDto>(schedule);
        return scheduleDto;
    }
    public async Task<IEnumerable<DoctorSchedulesReadDto>> GetActiveDoctorSchedulesAsync()
    {
        var schedules = await _unitOfWork.DoctorSchedulesReadRepository.FindAsync(schedule => schedule.IsActive,includes:"Doctor");
        if (schedules == null) throw new KeyNotFoundException("Active Doctor Schedules not found");
        var scheduleDtos = _mapper.Map<IEnumerable<DoctorSchedulesReadDto>>(schedules);
        return scheduleDtos;
    }
    public async Task DeleteDoctorSchedulesAsync(DoctorSchedulesDeleteDto doctorDeleteDto)
    {
        var schedule = await _unitOfWork.DoctorSchedulesReadRepository.GetByIdAsync(doctorDeleteDto.Id);
        if (schedule != null)
        {
            await _unitOfWork.DoctorSchedulesWriteRepository.DeleteAsync(schedule);
        }
        else
        {
            throw new ArgumentException("Schedule not found with the provided ID.");
        }
    }
    public async Task<IEnumerable<DoctorSchedulesReadDto>> GetAllDoctorSchedulesAsync()
    {
        var schedules = await _unitOfWork.DoctorSchedulesReadRepository.GetAllAsync(false,"Doctor");
        return _mapper.Map<IEnumerable<DoctorSchedulesReadDto>>(schedules);
    }
    public async Task<DoctorReadDto> GetDoctorSchedulesByDoctorNameAsync(string doctorFirstName)
    {
        var doctor = await _unitOfWork.DoctorReadRepository.FindAsync(
          d => d.FirstName.ToLower() == doctorFirstName.ToLower(),  
          asNoTracking: true,
          includes: new string[] { "DoctorSchedules" , "Hospital"}
      );

        if (!doctor.Any())
        {
            throw new Exception("No doctor found with the specified name.");
        }

        return _mapper.Map<DoctorReadDto>(doctor.FirstOrDefault());
    }
    public async Task UpdateDoctorSchedulesAsync(DoctorSchedulesUpdateDto doctorUpdateDto)
    {
        var schedule = await _unitOfWork.DoctorSchedulesReadRepository.GetByIdAsync(doctorUpdateDto.Id);
        if (schedule != null)
        {
            _mapper.Map(doctorUpdateDto, schedule);
            await _unitOfWork.DoctorSchedulesWriteRepository.UpdateAsync(schedule);
        }
        else
        {
            throw new ArgumentException("Schedule not found with the provided ID.");
        }
    }

}