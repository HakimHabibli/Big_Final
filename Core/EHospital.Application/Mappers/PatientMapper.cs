using AutoMapper;
using EHospital.Application.Dtos.Entites.Patient;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class PatientMapper : Profile
{
    public PatientMapper()
    {
        //TODO:Baxilacaq Action daxilinde nelere ehtiyac olsa  
        CreateMap<Patient, PatientDto>().ReverseMap();
        //CreateMap<Patient, PatientCreateDto>().ReverseMap();
        //CreateMap<Patient, PatientDto>().ReverseMap();
        //CreateMap<Patient, PatientDto>().ReverseMap();
        //CreateMap<Patient, PatientDto>().ReverseMap();
    }
}
