using AutoMapper;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class DoctorMapper : Profile
{
    public DoctorMapper()
    {
        CreateMap<Doctor, DoctorDto>().ReverseMap();
        CreateMap<Doctor, DoctorReadDto>().ReverseMap();
        CreateMap<Doctor, DoctorCreateDto>().ReverseMap();
        CreateMap<Doctor, DoctorDeleteDto>().ReverseMap();
        CreateMap<Doctor, DoctorUpdateDto>().ReverseMap();
    }
}
