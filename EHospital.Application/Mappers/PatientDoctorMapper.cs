using AutoMapper;
using EHospital.Application.Dtos.Entites.PatientDoctor;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class PatientDoctorMapper : Profile
{
    public PatientDoctorMapper()
    {
        CreateMap<PatientDoctor, PatientDoctorDto>().ReverseMap();
        CreateMap<PatientDoctor, PatientDoctorCreateDto>().ReverseMap();
        CreateMap<PatientDoctor, PatientDoctorDeleteDto>().ReverseMap();
        CreateMap<PatientDoctor, PatientDoctorUpdateDto>().ReverseMap();
        CreateMap<PatientDoctor, PatientDoctorReadDto>().ReverseMap();
    }
}