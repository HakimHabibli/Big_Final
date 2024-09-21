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
        CreateMap<Doctor, DoctorDeleteDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        CreateMap<Doctor, DoctorUpdateDto>().ReverseMap();
    }
}
