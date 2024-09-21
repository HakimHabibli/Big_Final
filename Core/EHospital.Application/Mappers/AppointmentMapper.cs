using AutoMapper;
using EHospital.Application.Dtos.Entites.Appointment;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class AppointmentMapper : Profile
{
    public AppointmentMapper()
    {
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<Appointment, AppointmentCreateDto>().ReverseMap();
        CreateMap<Appointment, AppointmentReadDto>().ReverseMap();
        CreateMap<Appointment, AppointmentUpdateDto>().ReverseMap();
        CreateMap<Appointment, AppointmentDeleteDto>().ReverseMap();
    }
}
