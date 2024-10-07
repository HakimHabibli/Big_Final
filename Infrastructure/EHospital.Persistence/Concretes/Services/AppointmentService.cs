using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Appointment;
using EHospital.Domain.Entities;

namespace EHospital.Application.Concretes.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAppointmentAsync(AppointmentCreateDto appointmentCreateDto)//+
    {
        var appointment = _mapper.Map<Appointment>(appointmentCreateDto);
        await _unitOfWork.AppointmentWriteRepository.CreateAsync(appointment);
    }

    public async Task DeleteAppointmentAsync(AppointmentDeleteDto appointmentDeleteDto)//+
    {
        var appointment = _mapper.Map<Appointment>(appointmentDeleteDto);
        await _unitOfWork.AppointmentWriteRepository.DeleteAsync(appointment);
    }

    public async Task<List<AppointmentReadDto>> GetAllAppointmentAsync()
    {
        var appointment = await _unitOfWork.AppointmentReadRepository
            .GetAllAsync(false, "Doctor", "Patient");

        return _mapper.Map<List<AppointmentReadDto>>(appointment);
    }

    public async Task<List<AppointmentReadDto>> GetAppointmentsByDoctorAsync(int doctorId)
    {
        var appointment = await _unitOfWork.AppointmentReadRepository.GetDoctorIdAsync(doctorId);
        return _mapper.Map<List<AppointmentReadDto>>(appointment);
    }

    public async Task<List<AppointmentReadDto>> GetAppointmentsByPatientAsync(int patientId)
    {
        var appointment = await _unitOfWork.AppointmentReadRepository.GetPatientIdAsync(patientId);
        return _mapper.Map<List<AppointmentReadDto>>(appointment);
    }

    public async Task UpdateAppointmentAsync(AppointmentUpdateDto appointmentUpdateDto)//+
    {
        var appointment = await _unitOfWork.AppointmentReadRepository.GetByIdAsync(appointmentUpdateDto.Id);
        if (appointment == null)
        {
            throw new KeyNotFoundException("Appointment not found.");
        }


        //_mapper.Map<Appointment>(appointmentUpdateDto);
        _mapper.Map(appointmentUpdateDto, appointment);

        await _unitOfWork.AppointmentWriteRepository.UpdateAsync(appointment);
    }
}