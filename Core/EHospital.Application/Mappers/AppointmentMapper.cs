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
        CreateMap<Appointment, AppointmentReadDto>()
            .ForMember(d => d.DoctorName, opt => opt.MapFrom(src => src.Doctor.FirstName))
            .ForMember(d => d.PatientName, opt => opt.MapFrom(src => src.Patient.FirstName))
            .ReverseMap();
        //Appointment modeli daxilindeki propertini dto daxilindeki propa mapliyirik
        CreateMap<Appointment, AppointmentUpdateDto>().ReverseMap();
        CreateMap<Appointment, AppointmentDeleteDto>().ReverseMap();
    }
}
